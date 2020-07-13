using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Impl;

namespace System.Services.SchedularItems
{
    public static class DateTimeSchedular
    {
        public async static void Start(int id)
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = await schedFact.GetScheduler();
            await sched.Start();
        }
    }
}
