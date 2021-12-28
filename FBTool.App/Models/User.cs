using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBTool.App.Views
{
    class User
    {
        public string Profile { get; set; }

        public string Id { get; set; }

        public string Proxy { get; set; }

        public string Status { get; set; }

        public User(string profile, string id, string proxy, string status)
        {
            Profile = profile;
            Id = id;
            Proxy = proxy;
            Status = status;
        }

    }

}
