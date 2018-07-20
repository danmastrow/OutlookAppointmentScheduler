namespace OutlookAppointmentSchedulerGUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using OutlookAppointmentScheduler;

    public partial class ModifyBookingForm : Form
    {
        private MainForm parent;
        private IBookingData oldBookingData;

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
            bookingEnabledInput.Enabled = bookingData.Enabled;
            bookingTypeInput.SelectedItem = bookingData.Type.ToString();
            bookingTimeInput.Value = new DateTime(2018, 1, 1) + bookingData.Time;
            bookingLocationInput.Text = bookingData.Location;
            bookingDurationInput.Value = bookingData.DurationInMinutes;
            bookingDaysInFutureInput.Value = bookingData.NumberOfDaysInFuture;
            emailSubjectInput.Text = bookingData.Subject;
            emailBodyInput.Text = bookingData.Body;
            emailRecipientsInput.Text = string.Join("\r\n", bookingData.Recipients);

            // TODO: Refactor this as Linq.
            foreach (var day in bookingData.DayBlackList)
            {
                var index = bookingDayBlackListInput.Items.IndexOf(day.ToString());

                bookingDayBlackListInput.SetSelected(index, true);
            }
        }

        private void ModifyBookingForm_Load(object sender, EventArgs e) { }

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

            var modifiedFileName = BookingDataFileWriter.WriteBookingDataToJsonFile(directory, bookingData, oldBookingData.FileName);
            MessageBox.Show($"{modifiedFileName} saved.");

            this.Hide();
            parent.RefreshData();
            parent.Show();
        }
    }
}
