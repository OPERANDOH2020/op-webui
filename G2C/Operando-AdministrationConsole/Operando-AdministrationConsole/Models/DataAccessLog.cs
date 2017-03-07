using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class DataAccessLog
    {
        public DateTime logDate { get; set; }
        public string requesterType { get; set; }
        public string requesterId { get; set; }
        public string logPriority { get; set; }
        public string logLevel { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string logType { get; set; }
        public string affectedUserId { get; set; }
        public bool viewed { get; set; }
    }

    
}