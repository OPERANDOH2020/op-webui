using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel
    {
        public string LogLevel;
        public DateTime LogDate;
        public string RequesterType;
        public string Title;
        public string Description;
        public string RequesterId;

        public DataAccessLogModel(DataAccessLog entity)
        {
            LogLevel = entity.logLevel;
            LogDate = entity.logDate;
            RequesterType = entity.requesterType;
            Title = entity.title;
            Description = entity.description;
            RequesterId = entity.requesterId;
        }
    }
}