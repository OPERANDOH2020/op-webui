using DemoDataExtract2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DemoDataExtract.Controllers
{
    public class ExtractsController : Controller
    {
        
        // GET: /Extracts
        public async Task<ActionResult> Index()
        {
            ViewBag.OspName = "FoodCoach";

            List<ExtractJob> jobsFoodcoach = await retrieveJobsFromBda();

            return View(jobsFoodcoach);
        }

        // GET: /Extracts/Subscription/{id}
        public async Task<ActionResult> Subscription(String id)
        {
            ExtractJob jobFoodcoach = await retrieveJobFromBda(id);

            return View(jobFoodcoach);
        }

        // GET: /Extracts/Schedule
        public async Task<ActionResult> Schedule(FormCollection collection)
        {
            String jobId = collection.Get("id");
            String name = collection.Get("name");
            String frequency = collection.Get("frequency");
            ExtractJobSubscription subscription = new ExtractJobSubscription(frequency);
            
            HttpResponseMessage responseMessage = await updateJobSubscriptionWithBda(subscription, jobId);

            // Work out appropriate content to display on the screen.
            String title = "Successful";
            String message = "Your subscription preferences were successfully updated.";
            if (responseMessage.IsSuccessStatusCode)
            {
                if (frequency.Equals("never"))
                {
                    message += " You will no longer receive extracts for " + name + ".";
                }
                else
                {
                    message += " You will now receive " + frequency + " extracts for " + name + ".";
                }
            }
            else
            { 
                title = "Error";
                message = "Something went wrong.";
            }
            ViewBag.Title = title;
            ViewBag.Message = message;

            return View();
        }

        private static async Task<HttpResponseMessage> updateJobSubscriptionWithBda(ExtractJobSubscription subscription, String jobId)
        {
            String strUri = "http://localhost:8080/test/bda/mc/osps/OspIdFoodCoach/jobs/" + jobId + "/subscription";

            String json = JsonConvert.SerializeObject(subscription);
            StringContent content = new StringContent(json);

            HttpResponseMessage responseMessage = null;
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(strUri);
                responseMessage = await client.PutAsync(uri, content);
            }
            return responseMessage;
        }

        private static async Task<ExtractJob> retrieveJobFromBda(String id)
        {
            String responseBodyBdaJob = await retrieveHttpGetBody("http://localhost:8080/test/bda/mc/osps/OspIdFoodCoach/jobs/" + id);
            ExtractJob job = JsonConvert.DeserializeObject<ExtractJob>(responseBodyBdaJob);
            return job;
        }


        private static async Task<List<ExtractJob>> retrieveJobsFromBda()
        {
            String responseBodyBdaFoodcoachJobs = await retrieveHttpGetBody("http://localhost:8080/test/bda/mc/osps/OspIdFoodCoach/jobs");
            ResponseBdaExtractJobs responseBdaFoodcoachJobs = JsonConvert.DeserializeObject<ResponseBdaExtractJobs>(responseBodyBdaFoodcoachJobs);
            return responseBdaFoodcoachJobs.Jobs;
        }

        private static async Task<String> retrieveHttpGetBody(String strUri)
        {
            HttpResponseMessage responseMessage = null;
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(strUri);
                responseMessage = await client.GetAsync(uri);
            }

            String responseBody = await responseMessage.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}