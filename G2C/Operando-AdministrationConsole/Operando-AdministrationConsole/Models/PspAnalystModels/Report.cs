using eu.operando.core.ldb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models.PspAnalystModels
{
    public class Report
    {
        public List<DataAccessLog> invalidLogs = new List<DataAccessLog>();
        public List<DataAccessLog> validLogs = new List<DataAccessLog>();
        public Boolean checkValid()
        {
            if(invalidLogs.Count == 0)
            {
               return true;
            }
             return false;
        }
    }
}