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
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            var directory = UserSettings.Default.BookingDirectory;
            var blackListDays = new List<DayOfWeek>();

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
                Time = bookingTimeInput.Value.TimeOfDay,
                Location = bookingLocationInput.Text,
                DurationInMinutes = (int)bookingDurationInput.Value,
                NumberOfDaysInFuture = (int)bookingDaysInFutureInput.Value,
                Body = emailBodyInput.Text,
                Subject = emailSubjectInput.Text,
                Recipients = emailRecipientsInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None),
                DayBlackList = blackListDays
            };

            Directory.CreateDirectory(directory); // Interestingly enough it doesnt matter whether this already exists when attempting to create.
            var fileName = $"{bookingData.Name.Replace(" ", "-").Trim()}{DateTime.Now.ToString(@"dd-MMM-yyyy")}.json";

            var invalidFileName = string.IsNullOrEmpty(fileName) ||
              fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

            if (invalidFileName) {
                using (StreamWriter file = File.CreateText(directory + "\\" + fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, bookingData);
                }

                MessageBox.Show($"{fileName.ToString()} Created");

                this.Hide();
                parent.RefreshData();
                parent.Show();
            }
            else
            {
                MessageBox.Show($"{fileName.ToString()} is an invalid filename, please rename the Booking Name.");
            }
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
            // Set default item to first.
            bookingTypeInput.SelectedItem = bookingTypeInput.Items[0];
        }
        private void labelType_Click(object sender, EventArgs e)
        {
        }
    }
}