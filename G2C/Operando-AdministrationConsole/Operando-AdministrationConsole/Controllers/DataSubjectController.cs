using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operando_AdministrationConsole.Controllers
{
    public class DataSubjectController : Controller
    {
        public ActionResult DataAccessLogs()
        {
            return View();
        }
        public ActionResult AccessPreferences()
        {
            return View();
        }

        
    }
}