using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.App.Views
{
    public class ReviewScheduler
    {
        public IScheduler scheduler { get; set; }

        public async void Start(String parameterFile, DateTimeOffset startTime)
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            await scheduler.Start();

            scheduler.Context.Put("parameterFile", parameterFile);

            IJobDetail job = JobBuilder.Create<ReviewJob>()
                    .WithIdentity("Job review")
                    .Build();

            //ITrigger trigger = TriggerBuilder.Create()
            //             .StartNow()
            //             .WithSimpleSchedule(x => x
            //                 .WithIntervalInSeconds(1))
            //             .Build();

            ITrigger trigger = TriggerBuilder.Create()
                         .StartAt(startTime.ToUniversalTime())
                         .Build();

            await scheduler.ScheduleJob(job, trigger);

        }

        public async void Stop(IScheduler scheduler)
        {
            if (scheduler.IsStarted)
            {
                await scheduler.Shutdown();
            }
        }
    }
}
