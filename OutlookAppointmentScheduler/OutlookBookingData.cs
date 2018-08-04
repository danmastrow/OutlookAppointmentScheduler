namespace OutlookAppointmentScheduler
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the data the OutlookBooking requires
    /// </summary>
    /// <seealso cref="OutlookAppointmentScheduler.IBookingData" />
    public class OutlookBookingData : IBookingData
    {
        /// <summary>Gets or sets the name of the booking.</summary>
        /// <value>The Booking name.</value>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IBookingData" /> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [JsonProperty("Enabled")]
        public bool Enabled { get; set; }

        /// <summary>Gets or sets the Booking type.</summary>
        /// <value>The Booking type.</value>
        [JsonProperty("Type")]
        public BookingType Type { get; set; }

        /// <summary>Gets or sets the times.</summary>
        /// <value>The booking times.</value>
        [JsonProperty("Times")]
        public IList<TimeSpan> Times { get; set; }

        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        [JsonProperty("Location")]
        public string Location { get; set; }

        /// <summary>Gets or sets the duration in minutes.</summary>
        /// <value>The duration in minutes.</value>
        [JsonProperty("DurationInMinutes")]
        public int DurationInMinutes { get; set; }

        /// <summary>Gets or sets the number of days in future.</summary>
        /// <value>The number of days in future.</value>
        [JsonProperty("NumberOfDaysInFuture")]
        public int NumberOfDaysInFuture { get; set; }

        /// <summary>Gets or sets the body.</summary>
        /// <value>The body.</value>
        [JsonProperty("Body")]
        public string Body { get; set; }

        /// <summary>Gets or sets the subject.</summary>
        /// <value>The subject.</value>
        [JsonProperty("Subject")]
        public string Subject { get; set; }

        /// <summary>Gets or sets the recipients.</summary>
        /// <value>The recipients.</value>
        [JsonProperty("Recipients")]
        public IList<string> Recipients { get; set; }

        /// <summary>Gets or sets the days that are blacklisted.</summary>
        /// <value>The day black list.</value>
        [JsonProperty("DayBlackList")]
        public IList<DayOfWeek> DayBlackList { get; set; }

        /// <summary>Gets or sets the name of the file.</summary>
        /// <value>The name of the file.</value>
        [JsonProperty("FileName")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the booking file has been read by the service.
        /// </summary>
        /// <value><c>true</c> if [file read]; otherwise, <c>false</c>.</value>
        [JsonProperty("FileRead")]
        [HideFromListView]
        public bool FileRead { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents the OutlookBookingData
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"Booking for {DurationInMinutes} minutes at {Location} for the Recipients: {{{String.Join(",", Recipients)}}}, at one of these times: {String.Join(",", Times)}";
        }
    }
}