using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu.operando.interfaces.aapi
{
    public interface IAapiClient
    {
        string GetServiceTicket(string ticketGrantingTicket, string serviceId);
    }
}
