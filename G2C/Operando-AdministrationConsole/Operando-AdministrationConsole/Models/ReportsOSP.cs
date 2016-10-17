using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class ReportManagerOSP
    {
        public Results resultsObj;
        public Schedules schedulesObj; 
    }


    public class ResultsrOSP
    {
        public int ID { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string Report { get; set; }
        public string ReportDescription { get; set; }
        public string ReportVersion { get; set; }
        public string[] OSPs { get; set; }
        public string FileName { get; set; }
        public List<Results> ResultList { get; set; }
    }


    public class SchedulesrOSP
    {
        public int ID { get; set; }
        public string[] OSPs { get; set; }
        public string Report { get; set; }
        public DateTime StartDate;
        public int RepeatEveryNumb;
        public string RepeatEveryType { get; set; }
        public string[] RepeatEveryTypeOption { get; set; }
        public string[] DayOfWeek { get; set; }
        public string[] DayOfWeekOption { get; set; }
        public int StoragePeriodNumb;
        public string StoragePeriodType { get; set; }
        public string[] StoragePeriodTypeOption { get; set; }
        public string DescriptionSchedules { get; set; }
        public List<Schedules> ScheduleList { get; set; }
    }
}