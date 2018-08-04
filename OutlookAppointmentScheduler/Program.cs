namespace OutlookAppointmentScheduler
{
    using System.Collections.Generic;
    using Quartz;
    using Topshelf;
    using Topshelf.Quartz;

    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                var startType = UserSettings.Default.StartType;
                if (startType == "TodayAt")
                {
                    x.Service<OutlookAppointmentService>(s =>
                    {

                        s.ConstructUsing(() => new OutlookAppointmentService());
                        s.WhenStarted((tc, hostControl) => tc.Start(hostControl));
                        s.WhenStopped((tc, hostControl) => tc.Stop(hostControl));

                        s.ScheduleQuartzJob(q =>
                            q.WithJob(() =>
                                JobBuilder.Create<OutlookBooking>().Build())
                            .AddTrigger(() =>
                                TriggerBuilder.Create()
                            .StartAt(DateBuilder.TodayAt
                                    (UserSettings.Default.ScheduleStartTime.Hours, UserSettings.Default.ScheduleStartTime.Minutes, UserSettings.Default.ScheduleStartTime.Seconds))
                                    .WithSimpleSchedule(builder => builder
                                        .WithIntervalInHours(UserSettings.Default.ScheduleIntervalInHours) // Every x hours from then on. (App config)
                                        .RepeatForever())
                                    .Build())
                            );
                    });
                }
                else if (startType == "StartNow")
                {
                    x.Service<OutlookAppointmentService>(s =>
                    {

                        s.ConstructUsing(() => new OutlookAppointmentService());
                        s.WhenStarted((tc, hostControl) => tc.Start(hostControl));
                        s.WhenStopped((tc, hostControl) => tc.Stop(hostControl));

                        s.ScheduleQuartzJob(q =>
                            q.WithJob(() =>
                                JobBuilder.Create<OutlookBooking>().Build())
                            .AddTrigger(() =>
                                TriggerBuilder.Create()
                                .StartNow() // Test trigger - Starts immediately.
                                   .WithSimpleSchedule(builder => builder
                                       .WithIntervalInHours(24) // Every x hours from then on. (App config)
                                       .RepeatForever())
                                   .Build())

                            );
                    });
                }
                else
                {
                    throw new System.Exception("Invalid UserSettings.StartType: Argument not recognised.");
                }

                x.RunAsLocalSystem()
                    .DependsOnEventLog()
                    .StartAutomatically()
                    .EnableServiceRecovery(rc => rc.RestartService(1));

                x.SetServiceName("OutlookAppointmentScheduler");
                x.SetDisplayName("OutlookAppointmentScheduler");
                x.SetDescription("OutlookAppointmentScheduler - Scheduled Outlook Appointment bookings to be sent at specified times.");
            });
        }
    }
}

