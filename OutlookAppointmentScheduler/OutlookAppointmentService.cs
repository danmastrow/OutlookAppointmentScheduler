﻿namespace OutlookAppointmentScheduler
{
    using Topshelf;

    /// <summary>The OutlookAppointment Topshelf Service.</summary>
    /// <seealso cref="Topshelf.ServiceControl" />
    public class OutlookAppointmentService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
