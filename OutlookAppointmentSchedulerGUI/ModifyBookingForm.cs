namespace OutlookAppointmentSchedulerGUI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using OutlookAppointmentScheduler;

    public partial class ModifyBookingForm : Form
    {
        private MainForm parent;
        private IBookingData oldBookingData;
        private IList<DateTimePicker> bookingTimes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyBookingForm" /> class.
        /// </summary>
        public ModifyBookingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyBookingForm"/> class.
        /// </summary>
        /// <param name="bookingData">The booking data.</param>
        public ModifyBookingForm(MainForm parent, IBookingData bookingData)
        {
            this.parent = parent;
            this.oldBookingData = bookingData;
            InitializeComponent();
            PopulateListViewItems();
            PrefillUserInputs(bookingData);
        }

        /// <summary>Populates the ListView items.</summary>
        private void PopulateListViewItems()
        {
            foreach (var val in Enum.GetValues(typeof(BookingType)))
            {
                bookingTypeInput.Items.Add(val.ToString());
            }

        }

        /// <summary>Prefills the user inputs from the BookingData.</summary>
        /// <param name="bookingData">The booking data.</param>
        private void PrefillUserInputs(IBookingData bookingData)
        {
            bookingNameInput.Text = bookingData.Name;
            bookingEnabledInput.Checked = bookingData.Enabled;
            bookingTypeInput.SelectedItem = bookingData.Type.ToString();
            bookingTimeInputPrimary.Value = new DateTime(2018, 1, 1) + bookingData.Times[0]; // TODO: Replace this with foreach loop over each time.
            bookingLocationInput.Text = bookingData.Location;
            bookingDurationInput.Value = bookingData.DurationInMinutes;
            bookingDaysInFutureInput.Value = bookingData.NumberOfDaysInFuture;
            emailSubjectInput.Text = bookingData.Subject;
            emailBodyInput.Text = bookingData.Body;
            emailRecipientsInput.Text = string.Join("\r\n", bookingData.Recipients);
            bookingTimes = new List<DateTimePicker>()
            {
                bookingTimeInputPrimary
            };

            foreach (var day in bookingData.DayBlackList)
            {
                var index = bookingDayBlackListInput.Items.IndexOf(day.ToString());

                bookingDayBlackListInput.SetSelected(index, true);
            }


            if (bookingData.Times.Count >= 2)
            {
                for (int i = 1; i < bookingData.Times.Count; i++)
                {
                    var bookingTimePickerOffset = new Size(0, 30);
                    var dateTimePickerPosition = Point.Add(bookingTimes.Last().Location, bookingTimePickerOffset);
                    var bookingTimePicker = new DateTimePicker();

                    bookingTimePicker.Location = dateTimePickerPosition;
                    bookingTimePicker.Size = bookingTimes.Last().Size;
                    bookingTimePicker.Format = DateTimePickerFormat.Time;
                    bookingTimePicker.Value = new DateTime(2018, 1, 1) + bookingData.Times[i];
                    bookingTimePicker.ShowUpDown = true;
                    bookingTimes.Add(bookingTimePicker);
                    this.Controls.Add(bookingTimePicker);
                    this.buttonRemoveBookingTime.Show();
                }
            }
            else
            {
                buttonRemoveBookingTime.Hide();
            }
        }

        private void ModifyBookingForm_Load(object sender, EventArgs e) { }
        protected override void OnClosed(EventArgs e)
        {
            parent.Show();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
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
                Enabled = bookingEnabledInput.Checked,
                Type = (BookingType)Enum.Parse(typeof(BookingType), bookingTypeInput.Text),
                Times = bookingTimes.Select(t => t.Value.TimeOfDay).ToList(),
                Location = bookingLocationInput.Text,
                DurationInMinutes = (int)bookingDurationInput.Value,
                NumberOfDaysInFuture = (int)bookingDaysInFutureInput.Value,
                Body = emailBodyInput.Text,
                Subject = emailSubjectInput.Text,
                Recipients = emailRecipientsInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None),
                DayBlackList = blackListDays
            };

            var modifiedFileName = BookingDataFileWriter.WriteBookingDataToJsonFile(directory, bookingData, oldBookingData.FileName);
            MessageBox.Show($"{modifiedFileName} saved.");

            this.Hide();
            parent.RefreshData();
            parent.Show();
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
    }
}
