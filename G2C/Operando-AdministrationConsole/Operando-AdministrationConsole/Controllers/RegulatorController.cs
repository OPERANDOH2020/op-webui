using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Operando_AdministrationConsole.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Controllers
{
    public class RegulatorController : Controller
    {

        // GET: Regulator
       

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult RegulationCompliance()
        {
            return View();
        }

        public ActionResult PolicyStatements()
        {
            return View();
        }

    }
}