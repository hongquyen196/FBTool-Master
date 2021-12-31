using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.App.Schedule
{
    public class JobHolder
    {
        public IJobDetail JobDetail;

        public ITrigger Trigger;
    }
}
