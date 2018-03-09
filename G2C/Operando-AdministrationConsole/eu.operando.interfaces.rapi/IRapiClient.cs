using System.Collections.Generic;
using System.Threading.Tasks;
using eu.operando.interfaces.rapi.Model;
using JetBrains.Annotations;

namespace eu.operando.interfaces.rapi
{
    public interface IRapiClient
    {
        /// <summary>
        /// Get the compliance report for an osp.
        /// </summary>
        ComplianceReport GetComplianceReportForOsp([NotNull] string osp, [NotNull] string serviceTicket);

    }
}
