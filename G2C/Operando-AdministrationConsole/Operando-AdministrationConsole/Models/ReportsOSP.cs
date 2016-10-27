using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class ReportManagerOSP
    {
        public ReportsOSP reportsObj;
        public ResultsOSP resultsObj;
        public SchedulesOSP schedulesObj;
    }

    public class ReportsOSP
    {
        public int ID { get; set; }
        public string Report { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Location { get; set; }
        public string Parameters { get; set; }
        public string[] OSPs { get; set; }
        public string[] OSPsOption { get; set; }
        public List<ReportsOSP> ReportList { get; set; }
    }

    public class ResultsOSP
    {
        public int ID { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string Report { get; set; }
        public string ReportDescription { get; set; }
        public string ReportVersion { get; set; }
        public string[] OSPs { get; set; }
        public string FileName { get; set; }
        public List<ResultsOSP> ResultList { get; set; }
    }


    public class SchedulesOSP
    {
        public int ID { get; set; }
        public string[] OSPs { get; set; }
        public string[] OSPsOption { get; set; }
        public string Report { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
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
        public DateTime LastRun { get; set; }
        public DateTime NextScheduled { get; set; }
        public int GiornoMese { get; set; }
        public DateTime GiornoAnno { get; set; }
        public List<SchedulesOSP> ScheduleList { get; set; }
        public List<SchedulesOSP> ScheduleDetailsList { get; set; }
    }
}