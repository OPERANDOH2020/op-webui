using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel : AbstractDataAccessLogModel
    {
        public string Title;
        public string RequesterId;

        public DataAccessLogModel(DataAccessLog entity) : base(entity)
        {
            Title = entity.title;
            RequesterId = entity.requesterId.Replace(UserIdToReplace, RoleToReplaceWith);
        }
    }
}