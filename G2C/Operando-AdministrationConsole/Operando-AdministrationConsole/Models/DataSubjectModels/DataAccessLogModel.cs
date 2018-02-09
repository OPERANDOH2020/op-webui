using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.core.ldb.Model;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel
    {
        public DateTime LogDateStart { get; set; }
        public DateTime? LogDateEnd { get; set; }
        public string RequesterId { get; set; }
        public string OspId { get; set; }

        public IList<string> RequestedFields { get; }
        public IList<string> GrantedFields { get; }
        public IList<string> DeniedFields => RequestedFields.Except(GrantedFields).ToList();


        public string LogDates => LogDateStart.ToString("G") +
                                  (LogDateEnd.HasValue ? " - " + LogDateEnd.Value.ToString("G") : "");

        public DataAccessLogModel(DataAccessLog entity, INiceStringConverter stringConverter)
        {
            LogDateStart = entity.logDate;
            RequesterId = stringConverter.NiceAccessorNameOrDefault(entity.requesterId);
            OspId = entity.ospId;

            RequestedFields = entity.arrayRequestedFields
                .Select(stringConverter.NiceResourceNameOrDefault)
                .ToList();

            GrantedFields = entity.arrayRequestedFields
                .Where(s => entity.arrayGrantedFields.Contains(s))
                .Select(stringConverter.NiceResourceNameOrDefault)
                .ToList();

        }

        public DataAccessLogModel(string ospId, string requesterId, IEnumerable<string> requestedFields, IEnumerable<string> grantedFields, DateTime logDateStart, DateTime? logDateEnd = null)
        {
            OspId = ospId;
            RequesterId = requesterId;

            RequestedFields = requestedFields.ToList();
            GrantedFields = grantedFields.ToList();

            LogDateStart = logDateStart;
            LogDateEnd = logDateEnd;
        }

        public override bool Equals(object that)
        {
            var model = that as DataAccessLogModel;
            return model != null && Equals(model);
        }

        protected bool Equals(DataAccessLogModel other)
        {
            return LogDateStart == other.LogDateStart &&
                   LogDateEnd == other.LogDateEnd &&
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