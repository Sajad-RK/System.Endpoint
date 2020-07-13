using System;
using Quartz;
using Quartz.Impl;

namespace System.Endpoint
{
    class Program
    {
        static async void Main(string[] args)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            
            IScheduler sched = await schedFact.GetScheduler();
            await sched.Start();

            IJobDetail job = JobBuilder.Create<Services.SchedularItems.SystemJobs>()
                .WithIdentity("", "").Build();


            //var t = Properties.Settings.Default.Username;
        }
    }
}
