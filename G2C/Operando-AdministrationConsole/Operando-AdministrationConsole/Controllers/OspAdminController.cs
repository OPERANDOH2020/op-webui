using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operando_AdministrationConsole.Controllers
{
    public class OspAdminController : Controller
    {
        // GET: OspAdmin
        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult DataExtracts()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult ReviewPolicy()
        {
            return View();
        }

        public ActionResult UserQuestionnaireGenerator()
        {
            return View();
        }


        

    }
}