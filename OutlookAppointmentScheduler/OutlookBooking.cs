﻿namespace OutlookAppointmentScheduler
{
    using Newtonsoft.Json;
    using Quartz;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// Responsible for sending an OutlookBooking with the IBookingData
    /// </summary>
    /// <seealso cref="OutlookAppointmentScheduler.IBooking" />
    /// <seealso cref="Quartz.IJob" />
    public class OutlookBooking : IBooking, IJob
    {
        private IList<IBookingData> bookingData;
        private readonly string fileSearchPattern = "*.json";

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookBooking"/> class.
        /// </summary>
        public OutlookBooking()
        {
            bookingData = PopulateBookingData(UserSettings.Default.BookingDirectory);
        }

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
            Console.WriteLine("Executing a FileOutlookBooking");
            Send(bookingData);
        }

        /// <summary>Gets the booking data from JSON files in a directory.</summary>
        /// <returns></returns>
        public IList<IBookingData> PopulateBookingData(string directory)
        {
            return this.DeserializeJsonToBookingData(directory);
        }

        /// <summary>Sends the specified booking data.</summary>
        /// <param name="bookingData">The booking data.</param>
        public void Send(IList<IBookingData> bookingData)
        {
            foreach (var booking in bookingData)
            {
                if (booking.Enabled)
                {
                    SendOutlookMeeting(booking);
                }
                //TODO: Set this in the JSON filebooking.FileRead = true;
            }
        }

        /// <summary>Deserializes every json file in a directory as BookingData.</summary>
        /// <param name="bookingDirectory">The booking directory.</param>
        /// <returns>BookingData</returns>
        private IList<IBookingData> DeserializeJsonToBookingData(string bookingDirectory)
        {
            IList<IBookingData> result = new List<IBookingData>();
            DirectoryInfo directoryInfo = new DirectoryInfo(bookingDirectory);
            Directory.CreateDirectory(bookingDirectory);

            foreach (var jsonFile in directoryInfo.GetFiles(fileSearchPattern))
            {
                using (StreamReader file = File.OpenText(jsonFile.FullName))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        IBookingData booking = serializer.Deserialize<OutlookBookingData>(reader);
                        booking.FileName = jsonFile.FullName;
                        result.Add(booking);
                    }
                }
            }
            return result;
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

        /// <summary>Checks whether the location and time is free, then sends and returns whether was free.</summary>
        /// <param name="booking">The booking.</param>
        /// <returns>Location is free or not prior to booking.</returns>
        private void SendOutlookMeeting(IBookingData booking)
        {
            Console.WriteLine($"Sending {booking.ToString()}");
            try
            {
                foreach (TimeSpan time in booking.Times)
                {
                    var startDate = DateTime.Now.AddDays(booking.NumberOfDaysInFuture).Date + time;
                    var endDate = startDate.AddMinutes(booking.DurationInMinutes);

                    // If booking day is blacklisted or not free, try the next time in the booking.
                    if (booking.DayBlackList.Contains(startDate.DayOfWeek))
                    {
                        Console.WriteLine($"{startDate} is blacklisted in this booking, booking not sent.");
                        continue;
                    }

                    bool isFree = LocationIsFree(startDate, booking.Location, new Outlook.Application());
                    if (!isFree)
                    {
                        Console.WriteLine($"{startDate} is not free at the specified location, booking not sent.");
                        continue;
                    }

                    var app = new Outlook.Application();
                    Outlook.AppointmentItem appointment = app.CreateItem(Outlook.OlItemType.olAppointmentItem);
                    appointment.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
                    appointment.Location = booking.Location;
                    appointment.Start = startDate;
                    appointment.End = endDate;
                    appointment.Body = booking.Body;
                    appointment.Subject = booking.Subject;
                    appointment.Recipients.Add(booking.Location);
                    foreach (var recipient in booking.Recipients)
                    {
                        appointment.Recipients.Add(recipient);
                    }

                    appointment.Recipients.ResolveAll();
                    //appointment.Display();
                    appointment.Send();
                    Console.WriteLine($"{booking} sent.");
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: OutlookMeeting failed to send: {ex.Message}");
            }

        }
    }
}