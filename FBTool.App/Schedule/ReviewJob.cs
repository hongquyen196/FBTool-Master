using FBTool.App.Constants;
using Quartz;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FBTool.App.Views
{
    public class ReviewJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var _parameter = context.JobDetail.JobDataMap.Get("parameterFile");

            Console.WriteLine(_parameter);

            Run(_parameter.ToString());
           
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
