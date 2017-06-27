using System;
using eu.operando.core.ldb.Model;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsole.Models.DashboardModels.WidgetModels
{
    public class DataRequestsModel : AbstractDataAccessLogModel
    {
        public DataRequestsModel(DataAccessLog log) : base(log)
        {
        }
    }
}