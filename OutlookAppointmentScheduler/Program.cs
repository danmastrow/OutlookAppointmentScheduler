namespace OutlookAppointmentScheduler
{
    using Topshelf;
    using Topshelf.Quartz;
    using Quartz;

    public class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(h =>
            {
                h.Service<OutlookAppointmentService>(s =>
                {
                    s.WhenStarted(service => service.OnStart());
                    s.WhenStopped(service => service.OnStop());
                    s.ConstructUsing(() => new OutlookAppointmentService());

                    s.ScheduleQuartzJob(q =>
                        q.WithJob(() =>
                            JobBuilder.Create<Appointment>().Build())
                            .AddTrigger(() => TriggerBuilder.Create()
                                .WithSimpleSchedule(b => b
                                    .WithIntervalInSeconds(10)
                                    .RepeatForever())
                                .Build()));
                });

                h.RunAsLocalSystem()
                    .DependsOnEventLog()
                    .StartAutomatically()
                    .EnableServiceRecovery(rc => rc.RestartService(1));

                h.SetServiceName("OutlookAppointment Scheduler");
                h.SetDisplayName("OutlookAppointment Scheduler");
                h.SetDescription("Automatically send Outlook appointments at specific times.");
            });
        }
    }
}