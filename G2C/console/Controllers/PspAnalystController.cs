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
using System.Net;
using System.Text;

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAnalystController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();

        private static readonly Uri RegulationsRoot = new Uri("http://192.168.99.177:8080/stub-pdb-0.0.1-SNAPSHOT/api/regulations/");

        // GET: PspAnalyst
        public async Task<ActionResult> Regulations()
        {
            List<Regulation> regulations = await helper.get<List<Regulation>>(RegulationsRoot.ToString()); //= await getAllRegulations();
            return View(regulations);
        }

        [HttpPost]
        public async Task<ActionResult> NewRegulation(Regulation regulation)
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(regulation), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(RegulationsRoot, OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRegulation(Regulation regulation)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(regulation), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(new Uri(RegulationsRoot, regulation.RegId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegulation(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(new Uri(RegulationsRoot, id));
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
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