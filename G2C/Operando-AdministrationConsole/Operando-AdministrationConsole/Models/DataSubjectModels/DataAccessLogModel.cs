using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel
    {
        public DateTime LogDateStart;
        public DateTime? LogDateEnd;
        public string RequesterId;

        public IList<string> GrantedFields;
        public IList<string> DeniedFields;

        public DataAccessLogModel(DataAccessLog entity)
        {
            LogDateStart = entity.logDate;
            RequesterId = entity.requesterId;
            GrantedFields = entity.arrayRequestedFields.Where(s => entity.arrayGrantedFields.Contains(s)).ToList();
            DeniedFields = entity.arrayRequestedFields.Where(s => !entity.arrayGrantedFields.Contains(s)).ToList();
        }

        public DataAccessLogModel(IList<DataAccessLogModel> models)
        {
            LogDateStart = models.Min(m => m.LogDateStart);
            LogDateEnd = models.Count > 1 ? (DateTime?) models.Max(m => m.LogDateStart) : null;
            RequesterId = models.Select(m => m.RequesterId).Distinct().Single();
            GrantedFields = models.SelectMany(m => m.GrantedFields).Distinct().ToList();
            DeniedFields = models.SelectMany(m => m.DeniedFields).Distinct().ToList();
        }
    }
}