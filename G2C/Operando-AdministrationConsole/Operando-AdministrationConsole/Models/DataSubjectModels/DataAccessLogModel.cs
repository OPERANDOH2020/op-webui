using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel
    {
        public DateTime LogDate;
        public string RequesterId;

        public IList<string> GrantedFields;
        public IList<string> DeniedFields;

        public DataAccessLogModel(DataAccessLog entity)
        {
            LogDate = entity.logDate;
            RequesterId = entity.requesterId;
            GrantedFields = entity.arrayRequestedFields.Where(s => entity.arrayGrantedFields.Contains(s)).ToList();
            DeniedFields = entity.arrayRequestedFields.Where(s => !entity.arrayGrantedFields.Contains(s)).ToList();
        }
    }
}