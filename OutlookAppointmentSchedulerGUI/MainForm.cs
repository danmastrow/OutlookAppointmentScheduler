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

    public partial class MainForm : Form
    {
        private const string fileSearchPattern = "*.json";
        private const string serviceNotInstalledMessage = "Service not installed.";
        private readonly string executableName = "OutlookAppointmentScheduler";
        private readonly string installArguments = "install --autostart";
        private readonly int pollInterval = 3000;
        private readonly string serviceName = "OutlookAppointmentScheduler";
        private readonly string uninstallArguments = "uninstall";

        private IList<IBookingData> bookingData;
        private Form settingsForm, createBookingForm;
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            IntiializeService();
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

        private void bookingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonAddBooking_Click(object sender, EventArgs e)
        {
            if (createBookingForm == null || createBookingForm.IsDisposed) {
                createBookingForm = new CreateBookingForm(this);
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
            if (bookingListView.SelectedItems.Count == 0)
                return;

            // The way I've done this to compare the View to the actual JSON files is storing the CreationTime in the Model
            // The reason I wanted this is that I didnt want to be forced to store the file name
            // Also I might use the Creation Time in the future for display.
            var directoryInfo = new DirectoryInfo(UserSettings.Default.BookingDirectory);
            foreach (var jsonFile in directoryInfo.GetFiles(fileSearchPattern))
            {
                foreach (var booking in this.bookingData)
                {
                    if (jsonFile.CreationTime == booking.CreationTime)
                    {
                        jsonFile.Delete();
                    }
                }
            }
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
            if (settingsForm == null || settingsForm.IsDisposed) {
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
                        IBookingData bookingData = serializer.Deserialize<OutlookBookingData>(reader);
                        bookingData.CreationTime = jsonFile.CreationTime;
                        result.Add(bookingData);
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
        /// <param name="bookingData">The booking data.</param>
        /// <returns></returns>
        private ListViewItem FormatBookingDataAsListViewItem(IBookingData bookingData)
        {
            var props = new List<string>();
            foreach (var prop in typeof(IBookingData).GetProperties())
            {
                string value = "";
                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(String))
                {
                    foreach (var collectionItem in prop.GetValue(bookingData) as IList)
                    {
                        value += $"{collectionItem};";
                    }
                }
                else
                {
                    value = prop.GetValue(bookingData).ToString();
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

            // Based upon the IBookingData Public Properties, Generate Columns
            foreach (var prop in typeof(IBookingData).GetProperties())
            {
                bookingListView.Columns.Add(prop.Name);
            }
        }

        /// <summary>Intiializes the service.</summary>
        private void IntiializeService()
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
        /// <param name="bookingData">The booking data.</param>
        private void PopulateListView(ListView listView, IList<IBookingData> bookingData)
        {
            bookingListView.Items.Clear();

            if (bookingData.Count == 0)
                return;

            foreach (var booking in bookingData)
            {
                var listViewData = FormatBookingDataAsListViewItem(booking);
                listViewData.Group = GetListViewGroupByHeader(listView, booking.Type.ToString());
                listView.Items.Add(listViewData);
            }
        }

        /// <summary>Refreshes the booking display.</summary>
        private void RefreshBookingDisplay()
        {
            // Read every .json file in the bookings directory and update the ListView
            this.bookingData = DeserializeJsonToBookingData(UserSettings.Default.BookingDirectory);
            PopulateListView(bookingListView, bookingData);
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

        /// <summary>Starts the service.</summary>
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