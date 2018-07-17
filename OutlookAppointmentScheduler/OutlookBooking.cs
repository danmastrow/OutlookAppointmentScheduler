namespace OutlookAppointmentScheduler
{
    using System;
    using System.Collections.Generic;
    using Quartz;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using System.Linq;

    /// <summary>
    /// Responsible for sending an OutlookBooking with the IBookingData
    /// </summary>
    /// <seealso cref="OutlookAppointmentScheduler.IBooking" />
    /// <seealso cref="Quartz.IJob" />
    public class OutlookBooking : IBooking, IJob
    {
        private IList<IBookingData> bookingData;

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// fires that is associated with the <see cref="T:Quartz.IJob" />.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <remarks>
        /// The implementation may wish to set a  result object on the
        /// JobExecutionContext before this method exits.  The result itself
        /// is meaningless to Quartz, but may be informative to
        /// <see cref="T:Quartz.IJobListener" />s or
        /// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's
        /// execution.
        /// </remarks>
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Execute OutlookBooking");
            Send(bookingData);
        }

        public OutlookBooking()
        {
            bookingData = PopulateBookingData();
        }


        /// <summary>Gets the booking data from the user settings.</summary>
        /// <returns></returns>
        public IList<IBookingData> PopulateBookingData()
        {
            var result = new List<IBookingData>();
            var recipients = new List<string>();
            this.DayBlackList = new List<DayOfWeek>();

            foreach (var day in UserSettings.Default.BookingDayBlackList)
            {
                this.DayBlackList.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), day));
            }

            foreach (var recipient in UserSettings.Default.BookingRecipients)
            {
                recipients.Add(recipient);
            }

            foreach (var bookingTime in UserSettings.Default.BookingTimesToCheck)
            {
                result.Add(new OutlookBookingData()
                {
                    Time = TimeSpan.Parse(bookingTime),
                    Location = UserSettings.Default.BookingLocation,
                    DurationInMinutes = UserSettings.Default.DurationOfBookingInMinutes,
                    NumberOfDaysInFuture = UserSettings.Default.BookingDaysInFuture,
                    Body = UserSettings.Default.BookingBodyText,
                    Subject = UserSettings.Default.BookingSubjectText,
                    Recipients = recipients
                });
            }

            return result;
        }

        /// <summary>Sends the specified booking data.</summary>
        /// <param name="bookingData">The booking data.</param>
        public void Send(IList<IBookingData> bookingData)
        {
            bool meetingFree = false;
            foreach (var booking in bookingData)
            {
                if (!meetingFree)
                {
                    meetingFree = SendOutlookMeeting(booking);
                }
            }
        }

        /// <summary>Checks whether the location and time is free, then sends and returns whether was free.</summary>
        /// <param name="booking">The booking.</param>
        /// <returns>Location is free or not prior to booking.</returns>
        private bool SendOutlookMeeting(IBookingData booking)
        {

            var startDate = DateTime.Now.AddDays(booking.NumberOfDaysInFuture).Date + booking.Time;
            var endDate = startDate.AddMinutes(booking.DurationInMinutes);

            if (DayBlackList.Contains(startDate.DayOfWeek))
                return false;

            var app = new Outlook.Application();
            Outlook.AppointmentItem appointment = app.CreateItem(Outlook.OlItemType.olAppointmentItem);
            appointment.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;

            appointment.Location = booking.Location;
            appointment.Start = startDate;
            appointment.End = endDate;

            appointment.Body = booking.Body;
            appointment.Subject = booking.Subject;

            foreach (var recipient in booking.Recipients)
            {
                appointment.Recipients.Add(recipient);
            }

            appointment.Recipients.Add(booking.Location);

            appointment.Recipients.ResolveAll();

            bool isFree = LocationIsFree(startDate, booking.Location, new Outlook.Application());

            if (isFree)
            {
                // Use this for debugging: appointment.Display();
                appointment.Send();
                Console.WriteLine($"{booking} sent.");
            }
            else
            {
                Console.WriteLine($"{booking} not free.");
            }
            return isFree;
        }

        /// <summary>Returns whether a location is available in Outlook.</summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="location">The location.</param>
        /// <param name="application">The Outlook application.</param>
        /// <returns>Boolean whether the location is free.</returns>
        private bool LocationIsFree(DateTime startDate, string location, Outlook.Application application)
        {
            Outlook.Recipient loc = application.Session.CreateRecipient(location);
            var freeHalfas = loc.FreeBusy(startDate, 30, true).Substring(0, 48);
            var timeInHalfas = (startDate.TimeOfDay.Hours * 2) + (startDate.TimeOfDay.Minutes / 30);
            return freeHalfas[timeInHalfas].ToString() == "0";
        }

        /// <summary>Gets or sets the days that are blacklisted.</summary>
        /// <value>The day black list.</value>
        public IList<DayOfWeek> DayBlackList { get; set; }
    }
}