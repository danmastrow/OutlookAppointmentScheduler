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
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            serviceController1.ServiceName = serviceName;
            serviceController1.MachineName = Environment.MachineName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string file = Path.Combine
            var process = Process.Start("OutlookAppointmentScheduler.exe");
            //serviceController1.Start();
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start("OutlookAppointmentScheduler.exe", "install --autostart");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            serviceController1.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            serviceController1.Stop();
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            var process = Process.Start("OutlookAppointmentScheduler.exe", "uninstall");
        }
    }
}
