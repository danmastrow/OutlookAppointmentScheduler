namespace OutlookAppointmentScheduler
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>Represents the interface of Booking Data.</summary>
    public interface IBookingData
    {
        /// <summary>Gets or sets the name of the booking.</summary>
        /// <value>The Booking name.</value>
        [JsonProperty("Name")]
        string Name{ get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IBookingData" /> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [JsonProperty("Enabled")]
        bool Enabled { get; set; }

        /// <summary>Gets or sets the Booking type.</summary>
        /// <value>The Booking type.</value>
        [JsonProperty("Type")]
        BookingType Type { get; set; }

        /// <summary>Gets or sets the time.</summary>
        /// <value>The time.</value>
        [JsonProperty("Time")]
        TimeSpan Time { get; set; }

        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        [JsonProperty("Location")]
        string Location { get; set; }

        /// <summary>Gets or sets the duration in minutes.</summary>
        /// <value>The duration in minutes.</value>
        [JsonProperty("DurationInMinutes")]
        int DurationInMinutes { get; set; }

        /// <summary>Gets or sets the number of days in future.</summary>
        /// <value>The number of days in future.</value>
        [JsonProperty("NumberOfDaysInFuture")]
        int NumberOfDaysInFuture { get; set; }

        /// <summary>Gets or sets the body.</summary>
        /// <value>The body.</value>
        [JsonProperty("Body")]
        string Body { get; set; }

        /// <summary>Gets or sets the subject.</summary>
        /// <value>The subject.</value>
        [JsonProperty("Subject")]
        string Subject { get; set; }

        /// <summary>Gets or sets the recipients.</summary>
        /// <value>The recipients.</value>
        [JsonProperty("Recipients")]
        IList<string> Recipients { get; set; }

        /// <summary>Gets or sets the days that are blacklisted.</summary>
        /// <value>The day black list.</value>
        [JsonProperty("DayBlackList")]
        IList<DayOfWeek> DayBlackList { get; set; }
    }
}