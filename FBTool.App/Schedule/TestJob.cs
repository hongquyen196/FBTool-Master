using FBTool.App.Constants;
using Quartz;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBTool.App.Views
{
    public class TestJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var _parameter = context.JobDetail.JobDataMap.Get("parameterFile");

            Console.WriteLine(_parameter);

            await Console.Out.WriteLineAsync("Job executed from " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
