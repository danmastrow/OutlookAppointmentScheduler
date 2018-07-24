namespace OutlookAppointmentSchedulerGUI
{
    using Newtonsoft.Json;
    using OutlookAppointmentScheduler;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using static System.Windows.Forms.ListViewItem;
    using Outlook = Microsoft.Office.Interop.Outlook;


    public partial class MainForm : Form
    {
        private readonly string fileSearchPattern = "*.json";
        private readonly string serviceNotInstalledMessage = "Service not installed.";
        private readonly string executableName = "OutlookAppointmentScheduler";
        private readonly string installArguments = "install --autostart";
        private readonly int pollInterval = 3000;
        private readonly string serviceName = "OutlookAppointmentScheduler";
        private readonly string uninstallArguments = "uninstall";

        private IList<IBookingData> bookingData;
        private Outlook.Application outlookApplication;
        private SettingsForm settingsForm;
        private CreateBookingForm createBookingForm;
        private ModifyBookingForm modifyBookingForm;
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            this.outlookApplication = new Outlook.Application();
            InitializeComponent();
            InitializeService();
            InitializeBookingListView();
            RefreshData();
            InitalizeTimer();
        }

        /// <summary>Refreshes all potentially changing data.</summary>
        public void RefreshData()
        {
            serviceStatusText.Text = ServiceStatusText();
            SetButtonStatusByServiceStatus();
            RefreshBookingDisplay();
        }

        /// <summary>
        /// Handles the ItemActivate event of the bookingListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bookingListView_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                if (bookingListView.SelectedItems.Count >= 2 || bookingListView.SelectedItems.Count == 0)
                    return;

                if (modifyBookingForm != null)
                    modifyBookingForm.Dispose();

                // Get first selected item where filename is the last header.
                // TODO: Refactor this, if the FileName is no longer the last Public Property on IBookingData then this will fail.
                var fileName = bookingListView.SelectedItems[0].SubItems.Cast<ListViewSubItem>().ToList().Last().Text;
                var booking = bookingData.Where(x => x.FileName == fileName).FirstOrDefault();

                this.modifyBookingForm = new ModifyBookingForm(this, booking, outlookApplication);
                this.Hide();
                modifyBookingForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("File could not be opened.");
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the bookingListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void bookingListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>Handles the Click event of the buttonAddBooking control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddBooking_Click(object sender, EventArgs e)
        {
            if (createBookingForm == null || createBookingForm.IsDisposed)
            {
                createBookingForm = new CreateBookingForm(this, outlookApplication);
            }
            this.Hide();
            createBookingForm.Show();
        }

        /// <summary>Handles the Click event of the buttonInstall control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonInstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName, installArguments);
        }

        /// <summary>Handles the Click event of the buttonLaunch control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName);
        }

        private void buttonRemoveBooking_Click(object sender, EventArgs e)
        {
            // TODO: If the button has been pressed for the current selection, disallow further removes (spams search).
            // TODO: set a boolean buttonRemovedClicked = true
            // TODO: on the listviewindex change reset this boolean to false
            if (bookingListView.SelectedItems.Count == 0)
                return;

            var directoryInfo = new DirectoryInfo(UserSettings.Default.BookingDirectory);
            foreach (var jsonFile in directoryInfo.GetFiles(fileSearchPattern))
            {
                foreach (var booking in this.bookingData)
                {
                    // Find booking by fullname.
                    if (jsonFile.FullName == bookingListView.SelectedItems[0].SubItems.Cast<ListViewSubItem>().ToList().Last().Text)
                    {
                        jsonFile.Delete();
                    }
                }
            }
            RefreshBookingDisplay();
        }

        /// <summary>Handles the Click event of the buttonRestart control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            StopService();
            serviceStatusText.Text = ServiceStatusText();
            serviceController1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, new TimeSpan(2500));
            StartService();
        }

        /// <summary>Handles the Click event of the buttonSettings control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                settingsForm = new SettingsForm(this);
            }
            this.Hide();
            settingsForm.Show();
        }

        /// <summary>Handles the Click event of the buttonStart control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartService();
        }

        /// <summary>Handles the Click event of the buttonStop control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopService();
        }

        /// <summary>Handles the Click event of the buttonUninstall control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName, uninstallArguments);
        }

        /// <summary>Deserializes every json file in a directory as BookingData.</summary>
        /// <param name="bookingDirectory">The booking directory.</param>
        /// <returns>BookingData</returns>
        private IList<IBookingData> DeserializeJsonToBookingData(string bookingDirectory)
        {
            IList<IBookingData> result = new List<IBookingData>();
            DirectoryInfo directoryInfo = new DirectoryInfo(bookingDirectory);
            Directory.CreateDirectory(bookingDirectory);

            foreach (var jsonFile in directoryInfo.GetFiles(fileSearchPattern))
            {
                using (StreamReader file = File.OpenText(jsonFile.FullName))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        IBookingData booking = serializer.Deserialize<OutlookBookingData>(reader);
                        booking.FileName = jsonFile.FullName;
                        result.Add(booking);
                    }
                }
            }

            return result;
        }

        /// <summary>Disables all buttons.</summary>
        private void DisableAllButtons()
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }
        }

        /// <summary>Formats the booking data as ListView item.</summary>
        /// <param name="booking">The booking data.</param>
        /// <returns></returns>
        private ListViewItem FormatBookingDataAsListViewItem(IBookingData booking)
        {
            var props = new List<string>();
            foreach (var prop in typeof(IBookingData).GetProperties())
            {
                string value = "";
                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(String))
                {
                    foreach (var collectionItem in prop.GetValue(booking) as IList)
                    {
                        value += $"{collectionItem};";
                    }
                }
                else
                {
                    value = prop.GetValue(booking).ToString();
                }
                props.Add(value);
            }
            return new ListViewItem(props.ToArray());
        }

        /// <summary>Gets a ListView group by the Header.</summary>
        /// <param name="listView">The list view.</param>
        /// <param name="header">The header.</param>
        /// <returns>ListViewGroup with the same header.</returns>
        private ListViewGroup GetListViewGroupByHeader(ListView listView, string header)
        {
            ListViewGroup result = null;
            foreach (ListViewGroup group in listView.Groups)
            {
                if (group.Header == header)
                {
                    result = group;
                    return result;
                }
            }
            return result;
        }

        /// <summary>Initalizes the timer used to Poll the service and JSON files.</summary>
        private void InitalizeTimer()
        {
            timer = new Timer();
            timer.Interval = pollInterval;
            serviceStatusText.Text = ServiceStatusText();
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        /// <summary>Initializes the booking ListView from BookingType enum and IBookingData.</summary>
        private void InitializeBookingListView()
        {
            // Foreach enum value in BookingType add a ListView Group
            foreach (var val in Enum.GetValues(typeof(BookingType)))
            {
                var group = new ListViewGroup(val.ToString());
                bookingListView.Groups.Add(group);
            }

            // Based upon the IBookingData Public Properties
            // Generate listviewdata, that does not have the HideFromListView attribute.
            foreach (var prop in typeof(IBookingData).GetProperties())
            {
                if (!prop.GetCustomAttributes(false)
                    .Any(a => a.GetType() == typeof(HideFromListView)))
                {
                    bookingListView.Columns.Add(prop.Name);
                }
            }

            bookingListView.ItemActivate += bookingListView_ItemActivate;
            //bookingListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>Intiializes the service.</summary>
        private void InitializeService()
        {
            serviceController1.ServiceName = serviceName;
            serviceController1.MachineName = Environment.MachineName;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>Populates the Booking ListView with all Booking.JSON files.</summary>
        /// <param name="booking">The booking data.</param>
        private void PopulateListView(ListView listView, IList<IBookingData> booking)
        {
            bookingListView.Items.Clear();

            if (booking.Count == 0)
                return;

            foreach (var book in booking)
            {
                var listViewData = FormatBookingDataAsListViewItem(book);
                listViewData.Group = GetListViewGroupByHeader(listView, book.Type.ToString());
                listView.Items.Add(listViewData);
            }
        }

        /// <summary>Refreshes the booking display.</summary>
        private void RefreshBookingDisplay()
        {
            // Read every .json file in the bookings directory and update the ListView
            this.bookingData = DeserializeJsonToBookingData(UserSettings.Default.BookingDirectory);
            PopulateListView(bookingListView, bookingData);
            bookingListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>Services the status text.</summary>
        /// <returns></returns>
        private string ServiceStatusText()
        {
            string result = "";
            try
            {
                serviceController1.Refresh();
                result = serviceController1.Status.ToString();
            }
            catch (Exception ex)
            {
                result = serviceNotInstalledMessage;
            }
            return result;
        }

        private void SetButtonStatusByServiceStatus()
        {
            var enabledButtons = new List<Button>();

            //switch (serviceStatusText)
            //{
            //    case System.ServiceProcess.ServiceControllerStatus.ContinuePending:
            //        DisableAllButtons();
            //        break;
            //    case System.ServiceProcess.ServiceControllerStatus.Paused:
            //        // ??? Start button here?
            //        break;
            //    case System.ServiceProcess.ServiceControllerStatus.PausePending:
            //        DisableAllButtons();
            //        break;
            //    case System.ServiceProcess.ServiceControllerStatus.Running:

            //        enabledButtons = new List<Button>
            //            {
            //                this.buttonRestart,
            //                this.buttonStop,
            //                this.buttonUninstall,
            //                this.buttonSettings
            //            };

            //        SetOnlyButtonsToEnabled(enabledButtons);

            //        break;
            //    case System.ServiceProcess.ServiceControllerStatus.StartPending:
            //        DisableAllButtons();
            //        break;
            //    case System.ServiceProcess.ServiceControllerStatus.Stopped:
            //        enabledButtons = new List<Button>
            //            {
            //                this.buttonRestart,
            //                this.buttonStart,
            //                this.buttonLaunch,
            //                this.buttonUninstall,
            //                this.buttonSettings
            //            };

            //        SetOnlyButtonsToEnabled(enabledButtons);
            //        break;
            //    case System.ServiceProcess.ServiceControllerStatus.StopPending:
            //        DisableAllButtons();
            //        break;
            //    default:
            //        break;
            //}

            //catch (Exception ex)
            //{
            //    // Service is not installed, disable the buttons except for install and launch
            //    enabledButtons = new List<Button>
            //    {
            //        this.buttonInstall,
            //        this.buttonLaunch,
            //        this.buttonSettings
            //    };

            //SetOnlyButtonsToEnabled(enabledButtons);
        }

        /// <summary>Sets the only buttons to enabled.</summary>
        /// <param name="enabledButtons">The enabled buttons.</param>
        private void SetButtonsToEnabled(IList<Button> enabledButtons)
        {
            foreach (var button in enabledButtons)
            {
                button.Enabled = true;
            }
        }

        /// <summary>Starts the service.</summary>f
        private void StartService()
        {
            serviceController1.Refresh();
            if (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                serviceController1.Start();
        }
        /// <summary>Stops the service.</summary>
        private void StopService()
        {
            if (serviceController1.CanStop)
            {
                serviceController1.Stop();
            }
        }
        /// <summary>Handles the Tick event of the Timer control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}