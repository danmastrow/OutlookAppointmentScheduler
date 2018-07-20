using System;
using System.Windows.Forms;
using OutlookAppointmentScheduler;
using static System.Windows.Forms.ComboBox;

namespace OutlookAppointmentSchedulerGUI
{
    public partial class ModifyBookingForm : Form
    {
        public ModifyBookingForm()
        {
            InitializeComponent();
        }

        public ModifyBookingForm(IBookingData bookingData)
        {
            InitializeComponent();
            this.bookingNameInput.Text = bookingData.Name;
            this.bookingEnabledInput.Enabled = bookingData.Enabled;
            this.bookingTypeInput.SelectedText = bookingData.Type.ToString();
            this.bookingTimeInput.Value = new DateTime(2018, 1, 1) + bookingData.Time;
            this.bookingDurationInput.Value = bookingData.DurationInMinutes;
            this.bookingDaysInFutureInput.Value = bookingData.NumberOfDaysInFuture;

            foreach (var day in bookingData.DayBlackList)
            {
                var index = bookingDayBlackListInput.Items.IndexOf(day.ToString());

                this.bookingDayBlackListInput.SetSelected(index, true);
            }
            //this.bookingDayBlackListInput.SetSelected()
            //this.bookingDayBlackListInput.SelectedItems = FindListBoxItemByName(this.bookingDayBlackListInput, "Sunday");

            this.emailSubjectInput.Text = bookingData.Subject;
            this.emailBodyInput.Text = bookingData.Body;
            this.emailRecipientsInput.Text = string.Join("\r\n", bookingData.Recipients);
        }
        private void ModifyBookingForm_Load(object sender, EventArgs e)
        {

        }

        //private int FindListBoxIndexItemByName(ListBox listbox, string name)
        //{
        //    return listbo

        //}
    }
}
