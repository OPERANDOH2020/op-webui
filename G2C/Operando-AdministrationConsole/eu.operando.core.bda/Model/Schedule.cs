using System;

namespace eu.operando.core.bda.Model
{
    public class Schedule
    {
        public string Id { get; set; }
        public string JobId { get; set; }
        public string OspScheduled { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan RepeatInterval { get; set; }
    }
}