﻿namespace OutlookAppointmentSchedulerGUI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using OutlookAppointmentScheduler;

    public partial class MainForm : Form
    {
        private readonly string serviceName = "OutlookAppointmentScheduler";
        private readonly string executableName = "OutlookAppointmentScheduler";
        private readonly string installArguments = "install --autostart";
        private readonly string uninstallArguments = "uninstall";

        private Timer timer;
        private Form settingsForm, createBookingForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            serviceController1.ServiceName = serviceName;
            serviceController1.MachineName = Environment.MachineName;
            PollService();
        }

        /// <summary>Handles the Click event of the buttonSettings control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (settingsForm == null) { settingsForm = new SettingsForm(this); }
            this.Hide();
            settingsForm.Show();
        }

        /// <summary>Handles the Click event of the buttonLaunch control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName);
        }

        /// <summary>Handles the Click event of the buttonInstall control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonInstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName, installArguments);
        }

        /// <summary>Handles the Click event of the buttonStart control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartService();
        }

        /// <summary>Starts the service.</summary>
        private void StartService()
        {
            serviceController1.Refresh();
            if (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                serviceController1.Start();
        }

        /// <summary>Handles the Click event of the buttonStop control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopService();
        }

        /// <summary>Stops the service.</summary>
        private void StopService()
        {
            if (serviceController1.CanStop)
            {
                serviceController1.Stop();
            }
        }

        /// <summary>Handles the Click event of the buttonUninstall control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName, uninstallArguments);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void PollService()
        {
            timer = new Timer();
            timer.Interval = 3000;
            serviceStatusText.Text = "Polling Service...";
            serviceStatusText.Text = ServiceStatusText();

            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the status text
            serviceStatusText.Text = ServiceStatusText();
            SetButtonStatusByServiceStatus();
            RefreshBookingDisplay();
        }


        private void RefreshBookingDisplay()
        {
            // Read every .json file in the bookings directory and update the ListView
            var bookingData = DeserializeJsonToBookingData(UserSettings.Default.BookingDirectory);
            PopulateListView(bookingData);
        }

        /// <summary>Deserializes every json file in a directory as BookingData.</summary>
        /// <param name="bookingDirectory">The booking directory.</param>
        /// <returns>BookingData</returns>
        private IList<IBookingData> DeserializeJsonToBookingData(string bookingDirectory)
        {
            IList<IBookingData> result = new List<IBookingData>();
            DirectoryInfo directoryInfo = new DirectoryInfo(bookingDirectory);

            foreach (var jsonFile in directoryInfo.GetFiles("*.json"))
            {
                using (StreamReader file = File.OpenText(jsonFile.FullName))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        IBookingData bookingData = serializer.Deserialize<OutlookBookingData>(reader);
                        result.Add(bookingData);
                    }
                }
            }

            return result;
        }

        private void PopulateListView(IList<IBookingData> bookingData)
        {
            listView1.Items.Clear();

            if (bookingData.Count == 0)
                return;

            foreach (var booking in bookingData)
            {
                var listViewData = FormatBookingDataAsListViewItem(booking);
                var listItem = new ListViewItem(listViewData);
                listView1.Items.Add(listItem);
            }
        }

        private string[] FormatBookingDataAsListViewItem(IBookingData bookingData)
        {
            string[] result = new string[listView1.Columns.Count];
            // TODO: Replace hardcoding with dynamic
            result[0] = bookingData.Enabled.ToString();
            result[1] = bookingData.Time.ToString();
            result[2] = bookingData.DurationInMinutes.ToString();
            result[3] = bookingData.Location;
            result[4] = String.Join("; ", bookingData.Recipients);
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

        /// <summary>Disables all buttons.</summary>
        private void DisableAllButtons()
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }
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
                result = "Service not installed.";
            }
            return result;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            StopService();
            serviceStatusText.Text = ServiceStatusText();
            serviceController1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, new TimeSpan(2500));
            StartService();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddBooking_Click(object sender, EventArgs e)
        {
            if (createBookingForm == null) { createBookingForm = new CreateBookingForm(this); }
            this.Hide();
            createBookingForm.Show();
        }
    }
}
