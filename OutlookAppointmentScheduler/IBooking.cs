namespace OutlookAppointmentScheduler
{
    using System.Collections.Generic;

    /// <summary>Represents the interface of a booking.</summary>
    public interface IBooking
    {
        /// <summary>Gets the booking data from user settings.</summary>
        /// <returns></returns>
        IList<IBookingData> PopulateBookingData();

        /// <summary>Sends the specified booking data.</summary>
        /// <param name="bookingData">The booking data.</param>
        void Send(IList<IBookingData> bookingData);
    }
}
