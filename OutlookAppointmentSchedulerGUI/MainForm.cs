using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAppointmentSchedulerGUI
{
    public partial class MainForm : Form
    {
        private readonly string serviceName = "OutlookAppointmentScheduler";
        private readonly string executableName = "OutlookAppointmentScheduler";
        private readonly string installArguments = "install --autostart";
        private readonly string uninstallArguments = "uninstall";

        private Timer timer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(this);
            this.Hide();
            settingsForm.Show();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName);
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName, installArguments);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void StartService()
        {
            serviceController1.Refresh();
            if (serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                serviceController1.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopService();
        }

        private void StopService()
        {
            if (serviceController1.CanStop)
            {
                serviceController1.Stop();
            }
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start(executableName, uninstallArguments);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serviceController1.ServiceName = serviceName;
            serviceController1.MachineName = Environment.MachineName;
            PollService();
        }

        private void PollService()
        {
            timer = new Timer();
            timer.Interval = 1000;
            serviceStatusText.Text = "Polling Service...";
            serviceStatusText.Text = ServiceStatusText();

            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            serviceStatusText.Text = ServiceStatusText();
        }

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
            StartService();
        }
    }
}
