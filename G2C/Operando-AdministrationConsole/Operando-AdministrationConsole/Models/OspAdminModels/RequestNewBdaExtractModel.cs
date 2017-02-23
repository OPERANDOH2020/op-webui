using System.ComponentModel.DataAnnotations;

namespace Operando_AdministrationConsole.Models.OspAdminModels
{
    public class RequestNewBdaExtractModel
    {
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string RequestSummary { get; set; }

    }
}