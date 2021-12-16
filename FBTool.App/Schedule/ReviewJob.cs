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
    public class ReviewJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var schedulerContext = context.Scheduler.Context;
            var parameter = schedulerContext.Get("parameterFile").ToString();

            MessageBox.Show(parameter);

            //Label scheduleStatus = (Label)FBReviewForm.shareObject["scheduleStatus"];
            //scheduleStatus.Text = "Job executed from " + Thread.CurrentThread.ManagedThreadId;

            Run(parameter);
           
            await Console.Out.WriteLineAsync("Job executed from " + Thread.CurrentThread.ManagedThreadId);
        }

        private void Run(string args)
        {
            using (Process process = Process.Start(Constant.REVIEW_EXECUTABLE, args))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
}
