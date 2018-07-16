namespace OutlookAppointmentScheduler
{
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the interface of Booking Data.</summary>
    public interface IBookingData
    {
        /// <summary>Gets or sets the number of days in future.</summary>
        /// <value>The number of days in future.</value>
        int NumberOfDaysInFuture { get; set; }

        /// <summary>Gets or sets the time.</summary>
        /// <value>The time.</value>
        TimeSpan Time { get; set; }

        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        string Location { get; set; }

        /// <summary>Gets or sets the body.</summary>
        /// <value>The body.</value>
        string Body { get; set; }

        /// <summary>Gets or sets the subject.</summary>
        /// <value>The subject.</value>
        string Subject { get; set; }

        /// <summary>Gets or sets the duration in minutes.</summary>
        /// <value>The duration in minutes.</value>
        int DurationInMinutes { get; set; }

        /// <summary>Gets or sets the recipients.</summary>
        /// <value>The recipients.</value>
        IList<string> Recipients { get; set; }
    }
}