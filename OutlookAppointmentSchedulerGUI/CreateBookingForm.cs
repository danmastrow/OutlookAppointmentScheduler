namespace OutlookAppointmentSchedulerGUI
{
    using System;
    using System.Windows.Forms;

    public partial class CreateBookingForm : Form
    {
        private readonly string bookingDirectory = @"./bookings";

        private Form parent;

        public CreateBookingForm()
        {
            InitializeComponent();
        }

        public CreateBookingForm(Form parent)
        {
            this.parent = parent;
            this.Location = parent.Location;
            InitializeComponent();
        }

        private void CreateBooking_Load(object sender, EventArgs e)
        {

        }

        //StringBuilder sb = new StringBuilder();
        //StringWriter sw = new StringWriter(sb);
        //var directory = bookingDirectory;

        //// Test booking object
        //IBookingData bookingData = new OutlookBookingData()
        //{
        //    NumberOfDaysInFuture = 7,
        //    Time = new TimeSpan(14, 30, 0),
        //    Location = "#AU Table Tennis",
        //    Body = "Making a booking",
        //    Subject = "TT",
        //    DurationInMinutes = 30,
        //    Recipients = new List<string>()
        //    {
        //        "Daniel Mastrowicz"
        //    }
        //};

        //Directory.CreateDirectory(directory); // Interestingly enough it doesnt matter whether this already exists when attempting to create.
        //using (StreamWriter file = File.CreateText(directory + "/test.json"))
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    serializer.Serialize(file, bookingData);
        //}

        protected override void OnClosed(EventArgs e)
        {
            parent.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }
    }
}
