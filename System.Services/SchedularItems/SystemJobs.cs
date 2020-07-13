using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Services.SchedularItems
{
    public class SystemJobs : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var id = context.Scheduler.Context;
            return Task.Run(() => Function1(DateTime.Now.ToString(), Convert.ToInt32(id.Get("id"))));
        }
        public string Function1(string dateTime, int id)
        {
            return string.Format("This job occured at {0} and ID => {1} ", dateTime, id);
        }
    }

}
