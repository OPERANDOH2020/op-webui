using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace Operando_AdministrationConsole.Controllers
{
    public class OspAdminController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();
        ReportManagerOSP reportManagerOSP = new ReportManagerOSP();

        private Uri OSPRoot(string id)
        {
            return new Uri($"http://localhost:8080/stub-pdb/api/OSP/{id}/privacy-policy");
        }

        public async Task<ActionResult> PrivacyPolicy()
        {
            // TODO: Get the OSP ID in some way
            string ospId = "ami";

            PrivacyPolicy policies = await
                helper.get<PrivacyPolicy>(OSPRoot(ospId).ToString());
            return View(policies);
        }

        public async Task<ActionResult> Reports()
        {
            List<BdaJob> executions = await helper.get<List<BdaJob>>("http://localhost:8080/stub-bda/bda/jobs?osp=Ami");
            return View("BigDataAnalytics", executions);
        }

        [HttpPost]
        public async Task<ActionResult> NewPrivacyPolicy(PrivacyPolicy policy)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(policy), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(OSPRoot(policy.OspPolicyId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePrivacyPolicy(PrivacyPolicy policy)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(policy), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(OSPRoot(policy.OspPolicyId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegulation(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(OSPRoot(id));
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }
        
        public ActionResult CareNeedsReport20170117()
        {
            return File("~/Content/CareNeedsReport20170117.pdf", "application/pdf");
        }

        public ActionResult DataExtracts()
        {
            return View();
        }
        
        public ActionResult UserQuestionnaireGenerator()
        {
            return View();
        }

        public async Task<ActionResult> BigDataAnalytics()
        {
            List<BdaJob> executions = await helper.get<List<BdaJob>>("http://localhost:8080/stub-bda/bda/jobs?osp=Ami");
            return View(executions);
        }
    }
}