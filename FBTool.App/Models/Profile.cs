using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.App.Views
{
    class Profile
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string User { get; set; }

        public string Proxy { get; set; }

        public string Status { get; set; }

        public string Process { get; set; }

        public Profile(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public static implicit operator string(Profile v)
        {
            throw new NotImplementedException();
        }
    }
}
