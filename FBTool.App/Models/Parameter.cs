using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.App.Views
{
    public class Parameter
    {
        public string _PAGE { get; set; }
        public List<string> _CONTENTS { get; set; }
        public List<string> _ATTACHMENTS { get; set; }
        public string _USERNAME { get; set; }
        public string _PROFILE_PATH { get; set; }
        public string _PROFILE_NAME { get; set; }
        public bool _HEADLESS { get; set; }
        public string _PROXY { get; set; }
        public string _CHROME_DRIVER { get; set; }
        public string _INJECTED_CREATE_YOUR_POST_REVIEW { get; set; }
        public string _INJECTED_GET_YOUR_POST_REVIEW { get; set; }

    }
}
