using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.operando.interfaces.aapi.Api;

namespace eu.operando.interfaces.aapi
{
    public class AapiClient : IAapiClient
    {
        public AapiClient()
        {
            string aapiBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            _aapiInstance = new DefaultApi(aapiBasePath);
        }

        public string GetServiceTicket(string ticketGrantingTicket, string serviceId)
        {
            string st = "";

            try
            {
                // OSP service ticket call
                st = _aapiInstance.AapiTicketsTgtPost(ticketGrantingTicket, serviceId);
                Debug.Print("Got RAPI Service Ticket: " + st);
            }
            catch (eu.operando.interfaces.aapi.Client.ApiException ex)
            {
                Debug.Print("Exception failed to make API call to AapiTicketsTgtPost: " + ex.Message);
            }

            return st;
        }

        private readonly DefaultApi _aapiInstance;
    }
}
