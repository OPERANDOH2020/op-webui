using System.Collections.Generic;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;
using eu.operando.core.pdb.cli.Model;
using Operando_AdministrationConsole.Helper;
using AccessPolicy = eu.operando.core.pdb.cli.Model.AccessPolicy;

namespace Operando_AdministrationConsole.Controllers
{

    public class DataSubjectController : Controller
    {

        public ActionResult DataAccessLogs()
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();

            List<DataAccessLog> stubLogs = AmiRandoStubHelper.GetStubAccessLogs();
            logList.AddRange(stubLogs);

            return View(logList);
        }

        public ActionResult AccessPreferences()
        {
            ViewBag.ospppList = AmiRandoStubHelper.GetAmiUserPrivacyPolicy();
            return View();
        }

        [HttpPost]
        public ActionResult AccessPreferences(FormCollection formCollection)
        {
            ViewBag.ospppList = AmiRandoStubHelper.GetAmiUserPrivacyPolicy();
            return View();
        }

        public ActionResult PrivacyWizard()
        {
            return View();
        }


    }
}