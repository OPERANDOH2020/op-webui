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
    public class PspAnalystController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();

        // GET: PspAnalyst
        public async Task<ActionResult> Regulations()
        {
            List<Regulation> regulations = await helper.get<List<Regulation>>("http://localhost:8080/stub-pdb/api/regulations"); //= await getAllRegulations();
            return View(regulations);
        }

        public ActionResult DataExtracts()
        {
            return View();
        }

        public ActionResult OspCompliance()
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

        public ActionResult UppManagement()
        {
            return View();
        }

        public async Task<ActionResult> BigDataAnalyticsConfig()
        {
            List<BdaJob> jobs = await helper.get<List<BdaJob>>("http://localhost:8080/stub-bda/bda/jobs?osp=Ami");
            BdaPageModel model = new BdaPageModel();
            model.Jobs = jobs;
            return View(model);
        }
    }
}