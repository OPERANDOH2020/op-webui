using System.ComponentModel.DataAnnotations;

namespace Operando_AdministrationConsole.Models.OspAdminModels
{
    public class RequestNewBdaExtractModel
    {
        public string RequesterName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        public string RequestSummary { get; set; }

    }
}