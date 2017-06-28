using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.operando.core.ldb.Model;

namespace eu.operando.core.ldb
{
    public interface ILdbClient
    {
        IList<DataAccessLog> GetDataAccessLogs(string userId);

        IList<DataAccessLog> GetNotifications(string userId, DateTime? startDate = null);

    }
}
