using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.core.ldb.Model;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel
    {
        public DateTime LogDateStart;
        public DateTime? LogDateEnd;
        public string RequesterId;

        public IList<string> GrantedFields;
        public IList<string> DeniedFields;

        public DataAccessLogModel(DataAccessLog entity, INiceStringConverter stringConverter)
        {
            LogDateStart = entity.logDate;
            RequesterId = stringConverter.NiceAccessorNameOrDefault(entity.requesterId);
            GrantedFields = entity.arrayRequestedFields
                .Where(s => entity.arrayGrantedFields.Contains(s))
                .Select(stringConverter.NiceResourceNameOrDefault)
                .ToList();
            DeniedFields = entity.arrayRequestedFields
                .Where(s => !entity.arrayGrantedFields.Contains(s))
                .Select(stringConverter.NiceResourceNameOrDefault)
                .ToList();
        }

        public DataAccessLogModel(IList<DataAccessLogModel> models)
        {
            LogDateStart = models.Min(m => m.LogDateStart);
            LogDateEnd = models.Count > 1 ? (DateTime?) models.Max(m => m.LogDateStart) : null;
            RequesterId = models.Select(m => m.RequesterId).Distinct().Single();
            GrantedFields = models.SelectMany(m => m.GrantedFields).Distinct().ToList();
            DeniedFields = models.SelectMany(m => m.DeniedFields).Distinct().ToList();
        }

        public override bool Equals(object that)
        {
            var model = that as DataAccessLogModel;
            return model != null && Equals(model);
        }

        protected bool Equals(DataAccessLogModel other)
        {
            return LogDateStart.Equals(other.LogDateStart) &&
                   LogDateEnd.Equals(other.LogDateEnd) &&
                   string.Equals(RequesterId, other.RequesterId) &&
                   GrantedFields.Count == other.GrantedFields.Count &&
                   GrantedFields.Zip(other.GrantedFields, string.Equals).All(b => b) &&
                   DeniedFields.Count == other.DeniedFields.Count &&
                   DeniedFields.Zip(other.DeniedFields, string.Equals).All(b => b);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = LogDateStart.GetHashCode();
                hashCode = (hashCode * 397) ^ LogDateEnd.GetHashCode();
                hashCode = (hashCode * 397) ^ (RequesterId != null ? RequesterId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GrantedFields != null ? GrantedFields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DeniedFields != null ? DeniedFields.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}