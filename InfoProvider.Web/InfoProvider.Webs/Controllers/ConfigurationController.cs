using InfoProvider.Webs.Models;
using InfoProvider.Webs.ServiceReference1;
using InfoProvider.Webs.Services;
using Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InfoProvider.Webs.Controllers
{
    public class ConfigurationController : Controller
    {
     
        //
        // GET: /Configuration/
        private static IInfoProviderCenter center = new InfoProviderCenterClient();
        private  Utilities m_Utilites;
        private LoginsManager m_LoginManager = new LoginsManager();
 
        public ConfigurationController()
        {
            m_Utilites = new Utilities(this);
        }
        public ActionResult UpdateList()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            center.UpdateRepository();
            sw.Stop();
            ViewBag.msg = "Update complete, took: " + sw.Elapsed;
            LogManager.Instance.WriteInfo("Manual update called by: " + m_Utilites.getUserIP() + " took: " + sw.Elapsed);
            return View();
        }
        [HttpGet]
        public ActionResult Log()
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + "Log" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".txt";

            string content = string.Empty;
            if (System.IO.File.Exists(filepath))
            {
                string[] logLines = System.IO.File.ReadAllLines(filepath);
                content = m_Utilites.covnertStringArrayToString(logLines, "<br>");
            }
            return Content(content);
        }
        public ActionResult Logins()
        {

            return View(m_LoginManager.GetUsersLoggedIn());
        }

      
    }
}
