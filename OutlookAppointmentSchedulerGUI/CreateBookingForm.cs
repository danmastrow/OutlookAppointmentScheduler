namespace OutlookAppointmentSchedulerGUI
{
    using Newtonsoft.Json;
    using OutlookAppointmentScheduler;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public partial class CreateBookingForm : Form
    {
        private MainForm parent;

        public CreateBookingForm()
        {
            InitializeComponent();
        }

        public CreateBookingForm(MainForm parent)
        {
            this.parent = parent;
            this.Location = parent.Location;
            InitializeComponent();
            IntializeListViews();
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var directory = UserSettings.Default.BookingDirectory;
            var blackListDays = new List<DayOfWeek>();
            var fullFileName = BookingDataFileWriter.CreateBookingFileName(directory, bookingNameInput.Text);
            // Map all Black Listed Days from the List input.
            foreach (var day in bookingDayBlackListInput.SelectedItems)
            {
                blackListDays.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day.ToString()));
            }

            // Map BookingData from Inputs
            IBookingData bookingData = new OutlookBookingData()
            {
                Name = bookingNameInput.Text,
                Enabled = bookingEnabledInput.Enabled,
                Type = (BookingType)Enum.Parse(typeof(BookingType), bookingTypeInput.Text),
                Times = new List<TimeSpan>() { bookingTimeInput.Value.TimeOfDay }, // TODO: Replace this with multiple time options
                Location = bookingLocationInput.Text,
                DurationInMinutes = (int)bookingDurationInput.Value,
                NumberOfDaysInFuture = (int)bookingDaysInFutureInput.Value,
                Body = emailBodyInput.Text,
                Subject = emailSubjectInput.Text,
                Recipients = emailRecipientsInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None),
                DayBlackList = blackListDays,
                FileRead = false,
                FileName = fullFileName
            };

            var createdFileName = BookingDataFileWriter.WriteBookingDataToJsonFile(directory, bookingData, fullFileName);
            MessageBox.Show($"{fullFileName} Created");

            this.Hide();
            parent.RefreshData();
            parent.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CreateBooking_Load(object sender, EventArgs e)
        {
        }

        private void IntializeListViews()
        {
            foreach (var val in Enum.GetValues(typeof(BookingType)))
            {
                bookingTypeInput.Items.Add(val.ToString());
            }

            // Set defaults
            bookingTypeInput.SelectedItem = bookingTypeInput.Items[0];
            bookingTimeInput.Format = DateTimePickerFormat.Time;
            bookingTimeInput.Value = new DateTime(2018, 1, 1) + UserSettings.Default.DefaultBookingTime;
            AcceptButton = buttonCreate;
        }
        private void labelType_Click(object sender, EventArgs e)
        {
        }

        private void bookingTimeInput_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}