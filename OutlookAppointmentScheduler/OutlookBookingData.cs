namespace OutlookAppointmentScheduler
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the data the OutlookBooking requires
    /// </summary>
    /// <seealso cref="OutlookAppointmentScheduler.IBookingData" />
    public class OutlookBookingData : IBookingData
    {
        /// <summary>Gets or sets the time.</summary>
        /// <value>The time.</value>
        public TimeSpan Time { get; set; }

        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; set; }

        /// <summary>Gets or sets the duration in minutes.</summary>
        /// <value>The duration in minutes.</value>
        public int DurationInMinutes { get; set; }

        /// <summary>Gets or sets the number of days in future.</summary>
        /// <value>The number of days in future.</value>
        public int NumberOfDaysInFuture { get; set; }

        /// <summary>Gets or sets the body.</summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>Gets or sets the subject.</summary>
        /// <value>The subject.</value>
        public string Subject { get; set; }

        /// <summary>Gets or sets the recipients.</summary>
        /// <value>The recipients.</value>
        public IList<string> Recipients { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the OutlookBookingData
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{Time} at {Location} for {DurationInMinutes} minutes in {NumberOfDaysInFuture} days";
        }
    }
}