using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FBTool.App.Views
{
    public class ReviewScheduler
    {
        public IScheduler scheduler { get; set; }

        public Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>> jobs = new Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>>();


        public async void Start(string parameterFile, DateTimeOffset startTime)
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ReviewJob>()
                    .WithIdentity("Job test", parameterFile)
                    .Build();

            job.JobDataMap.Put("parameterFile", parameterFile);

            ITrigger trigger = TriggerBuilder.Create()
                         .WithIdentity("Trigger test", parameterFile)
                         .StartAt(startTime.ToUniversalTime())
                         .Build();

            jobs.Add(job, new List<ITrigger> { trigger });
        }

        public async Task AddToSchedule()
        {
            await scheduler.ScheduleJobs(jobs, false);
            jobs.Clear();
            Console.WriteLine("Done.");
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
