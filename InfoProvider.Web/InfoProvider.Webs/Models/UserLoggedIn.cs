using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoProvider.Webs.Models
{
    public class UserLoggedIn
    {
        public DateTime Time { get; set; }
        public string MachineName { get; set; }
        public string IP { get; set; }
        public override string ToString()
        {
            return "Time:["+ Time.ToString() + "] MachineName:[" + MachineName + "] IP:[" + IP+"]";
        }
    }
}
