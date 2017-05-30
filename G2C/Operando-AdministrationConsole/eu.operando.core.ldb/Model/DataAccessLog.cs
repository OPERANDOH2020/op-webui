using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu.operando.core.ldb.Model
{
    public class DataAccessLog
    {
        public const string AccessDeniedTitle = "Access denied";
        public const string AccessGrantedTitle = "Access granted";

        public DateTime logDate;
        public string requesterType;
        public string requesterId;
        public string logPriority;
        public string logLevel;
        public string title;
        public string description;
        public string logType;
        public string affectedUserId;
    }
}
