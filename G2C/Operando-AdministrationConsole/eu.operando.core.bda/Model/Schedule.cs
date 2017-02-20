namespace eu.operando.core.bda.Model
{
    public class Schedule
    {
        public string OspScheduled { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string RepeatIntervalUnit { get; set; }
        public string RepeatIntervalValue { get; set; }
        public string RepeatOn { get; set; }
        public string StoragePeriod { get; set; }
    }
}