using System.ComponentModel.DataAnnotations;

namespace Operando_AdministrationConsole.Models.OspAdminModels
{
    public class RequestNewBdaExtractModel
    {
        [Display(Name = "Requester name")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string RequesterName { get; set; }

        [Display(Name = "Contact email")]
        [Required(ErrorMessage = "Please provide a valid email address.")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string ContactEmail { get; set; }

        [Display(Name = "Request summary")]
        [Required(ErrorMessage = "Please provide a summary of the reason for your request.")]
        public string RequestSummary { get; set; }

    }
}