namespace OutlookAppointmentScheduler
{
    using System;
    using Topshelf;

    /// <summary>
    /// The OutlookAppointment Topshelf Service.
    /// </summary>
    public class OutlookAppointmentService
    {
        /// <summary>
        /// Starts this instance.
        /// This has been hardcoded to true, otherwise the service doesnt run.
        /// </summary>
        /// <returns>True</returns>
        public bool Start()
        {
            Console.WriteLine("Service Started");
            return true;
        }

        /// <summary>
        /// Stops this instance. This has been hardcoded to true, otherwise the service doesnt run.
        /// </summary>
        /// <returns>True</returns>
        public bool Stop()
        {
            return true;
        }
    }
}
