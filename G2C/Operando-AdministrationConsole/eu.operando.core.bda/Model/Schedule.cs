using System;

namespace eu.operando.core.bda.Model
{
    public class Schedule
    {
        public string OspScheduled { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan RepeatInterval { get; set; }
        public string RepeatOn { get; set; }
        public TimeSpan StoragePeriod { get; set; }
    }
}