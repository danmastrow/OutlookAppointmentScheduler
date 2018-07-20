namespace OutlookAppointmentSchedulerGUI
{
    using System;
    using System.Windows.Forms;
    using OutlookAppointmentScheduler;

    public partial class ModifyBookingForm : Form
    {
        private MainForm parent;

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
    }
}
