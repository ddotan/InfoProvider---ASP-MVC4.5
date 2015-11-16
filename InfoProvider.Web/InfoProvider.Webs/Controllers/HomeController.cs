using InfoProvider.Webs.Models;
using InfoProvider.Webs.ServiceReference1;
using InfoProvider.Webs.Services;
using Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoProvider.Webs.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private static LoginsManager LoginManager = new LoginsManager();
        private Utilities m_Utilites;
        private static RMSAgentManager m_RMSAgentManager = RMSAgentManager.Instance;
        public HomeController()
        {
            m_Utilites = new Utilities(this);
        }
        public ActionResult Index()
        {
            LoginManager.Add(new UserLoggedIn() { IP = m_Utilites.getUserIP(), MachineName = m_Utilites.getHostnameFromIP(m_Utilites.getUserIP()), Time = DateTime.Now });
            List<RMSAgent> agents = m_RMSAgentManager.GetAgents();
            ViewBag.updateTime = m_RMSAgentManager.UpdateTime;
            ViewBag.mainMT = m_RMSAgentManager.MtCertPath;
            return View(agents);
        }


    }
}

