using System;
using System.Windows.Forms;

namespace OutlookAppointmentSchedulerGUI
{
    public partial class SettingsForm : Form
    {
        private Form parent;

        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Form parent)
        {
            this.parent = parent;
            this.Location = parent.Location;
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            parent.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Read the OutlookAppointmentScheduler.exe.config
        }
    }
}