using System;
using System.Collections.Generic;

namespace DemoDataExtract2.Models
{
    public class ResponseBdaExtractJobs
    {
        public List<ExtractJob> Jobs { get; set; }
    }
    
    public class ExtractJob
    {
        public string JobId { get; set; }
        public string JobName { get; set; }
        public ExtractJobSubscription Subscription { get; set; }
        public string Status { get; set; }
        public string DownloadLink { get; set; }
    }

    public class ExtractJobSubscription
    {
        public String Frequency { get; set; }

        public ExtractJobSubscription(String Frequency)
        {
            this.Frequency = Frequency;
        }
    }
}