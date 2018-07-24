namespace OutlookAppointmentSchedulerGUI
{
    using Newtonsoft.Json;
    using OutlookAppointmentScheduler;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Linq;
    using System.Drawing;
    using Outlook = Microsoft.Office.Interop.Outlook;


    public partial class CreateBookingForm : Form
    {
        private MainForm parent;
        private List<DateTimePicker> bookingTimes;
        private Outlook.Application outlookApplication;

        public CreateBookingForm()
        {
            InitializeComponent();
        }

        public CreateBookingForm(MainForm parent)
        {
            this.parent = parent;
            this.Location = parent.Location;
            this.outlookApplication = new Outlook.Application();
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
            var allBookingTimes = new List<TimeSpan>();
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
                Enabled = bookingEnabledInput.Checked,
                Type = (BookingType)Enum.Parse(typeof(BookingType), bookingTypeInput.Text),
                Times = bookingTimes.Select(t => t.Value.TimeOfDay).ToList(),
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
            bookingTimeInputPrimary.Format = DateTimePickerFormat.Time;
            bookingTimeInputPrimary.Value = new DateTime(2018, 1, 1) + UserSettings.Default.DefaultBookingTime;
            bookingLocationInput.Text = UserSettings.Default.DefaultBookingLocation;
            // Add the intial Booking Time
            bookingTimes = new List<DateTimePicker>()
            {
                bookingTimeInputPrimary
            };

            //AcceptButton = buttonCreate;
        }
        private void labelType_Click(object sender, EventArgs e)
        {
        }

        private void bookingTimeInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddBookingTime_Click(object sender, EventArgs e)
        {
            // If user wants to add more times to the booking.
            // Create DatetimePicker 30px below the next item in the bookingTimes
            var bookingTimePickerOffset = new Size(0, 30);
            var dateTimePickerPosition = Point.Add(bookingTimes.Last().Location, bookingTimePickerOffset);
            var bookingTimePicker = new DateTimePicker();

            bookingTimePicker.Location = dateTimePickerPosition;
            bookingTimePicker.Size = bookingTimes.Last().Size;
            bookingTimePicker.Format = DateTimePickerFormat.Time;
            bookingTimePicker.Value = new DateTime(2018, 1, 1) + UserSettings.Default.DefaultBookingTime;
            bookingTimePicker.ShowUpDown = true;
            bookingTimes.Add(bookingTimePicker);
            this.Controls.Add(bookingTimePicker);
            this.buttonRemoveBookingTime.Show();
        }

        private void buttonRemoveBookingTime_Click(object sender, EventArgs e)
        {
            if (bookingTimes.Count >= 2)
            {
                this.Controls.Remove(bookingTimes.Last());
                this.bookingTimes.Remove(bookingTimes.Last());
                if (bookingTimes.Count == 1)
                    this.buttonRemoveBookingTime.Hide();
            }
        }

        private void bookingTimeInputPrimary_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bookingLocationInput_TextChanged(object sender, EventArgs e)
        {
            var validLocation = ValidateRecipient(this.bookingLocationInput.Text);
            if (validLocation)
            {
                this.bookingLocationInput.ForeColor = Color.Green;

            }
            else
            {
                this.bookingLocationInput.ForeColor = Color.Red;
            }
        }

        private bool ValidateRecipient(string recipient)
        {
            return outlookApplication.Session.CreateRecipient(recipient).Resolve();
        }

        private void emailRecipientsInput_TextChanged(object sender, EventArgs e)
        {
            var oldInput = emailRecipientsInput.Text;
            var selectedLine = emailRecipientsInput.SelectionStart;
            emailRecipientsInput.Text = "";

            if (oldInput.Contains("\n"))
            {
                foreach (var line in oldInput.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {

                    var color = ValidateRecipient(line) ? Color.Green : Color.Red;
                    emailRecipientsInput.AppendText(line, color);
                    emailRecipientsInput.AppendText("\n");
                }
                //emailRecipientsInput.Text = oldInput;
            }
            else
            {
                var color = ValidateRecipient(oldInput) ? Color.Green : Color.Red;
                emailRecipientsInput.AppendText(oldInput, color);
            }

            emailRecipientsInput.SelectionStart = selectedLine;
        }
    }
}