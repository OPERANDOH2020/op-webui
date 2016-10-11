using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAdminController : Controller
    {
        // GET: PspAdmin
        public ActionResult ReportsConfig()
        {
            return View();
        }
    }
}