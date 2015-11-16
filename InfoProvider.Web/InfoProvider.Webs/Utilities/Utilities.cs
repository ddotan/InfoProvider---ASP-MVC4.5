using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InfoProvider.Webs.Models
{
    public  class Utilities
    {
        private Controller m_Controller;
        public Utilities(Controller i_Controller)
        {
            m_Controller = i_Controller;
        }
        public  string covnertStringArrayToString(string[] i_StrArray,string i_SeperatedBy)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in i_StrArray)
            {
                builder.Append(value);
                builder.Append(i_SeperatedBy);

                //builder.Append("<br>");
            }
            return builder.ToString();
        }
        public string getUserIP()
        {
            string ipList = m_Controller.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return m_Controller.Request.ServerVariables["REMOTE_ADDR"];
        }
        public string getHostnameFromIP(string i_ip)
        {
            string hostname = string.Empty;
            try
            {
                System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(i_ip);
                hostname = ip.HostName;
            }
            catch (Exception ex)
            {

            }
            return hostname;
        }
    }
}