using System;

namespace eu.operando.core.bda.Model
{
    public class ExtractionRequest
    {
        /// <summary>
        /// Who has made this request?
        /// </summary>
        public string RequesterName { get; set; }

        /// <summary>
        /// What is the contact email of the person making this request?
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// What description has the requester given to support their request?
        /// </summary>
        public string RequestSummary { get; set; }

        /// <summary>
        /// Which OSP does the requester represent?
        /// </summary>
        public string Osp { get; set; }

        /// <summary>
        /// When was the request made? UTC time.
        /// </summary>
        public DateTime RequestDate { get; set; }

    }
}