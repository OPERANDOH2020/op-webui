using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel : AbstractDataAccessLogModel
    {
        public string Requester;
        public string Title;
        public string RequesterId;

        public DataAccessLogModel(DataAccessLog entity) : base(entity)
        {
            Requester = ParseRequester(entity);
            Title = entity.title;
            RequesterId = entity.requesterId;
        }

        private static string ParseRequester(DataAccessLog entity)
        {
            return entity.requesterType.Replace(UserIdToReplace, RoleToReplaceWith);
        }
    }
}