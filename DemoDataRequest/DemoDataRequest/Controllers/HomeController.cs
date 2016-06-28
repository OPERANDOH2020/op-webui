using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoDataRequest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MessageRequest1 = "This will show request data when the request is sent.";
            
            return View();
        }

        public async Task<ActionResult> RequestAccess()
        {
            String json = "{\"serviceTicket\":\"ticket\", \"ospId\":\"FoodCoach\", \"role\":\"1\", \"queryId\":\"FoodCoach;2\", \"userIds\":[\"36\"]}";
            ViewBag.MessageRequest1 = "message body: " + json;

            HttpResponseMessage responseMessage = null;
            using (var client = new HttpClient())
            {
                Uri uri = new Uri("http://localhost/gatekeeper/api/data_request");
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                responseMessage = await client.PostAsync(uri, content);
            }

            String responseString = await responseMessage.Content.ReadAsStringAsync();
            HttpStatusCode statusCode = responseMessage.StatusCode;
            ViewBag.MessageResponse2 = "Message status code: " + (int) statusCode + " (" + statusCode + ")";

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                ViewBag.MessageResponse1 = "Access granted.";
                ViewBag.MessageResponse3 = "Message body: " + responseString;
            }
            else
            {
                ViewBag.MessageResponse1 = "Access denied.";
            }

            return View("Index");
        }
    }
}