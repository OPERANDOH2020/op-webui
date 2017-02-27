using System;

namespace Operando_AdministrationConsole.Models.PspAnalystModels
{
    public class BigDataScheduleModel
    {
        /// <summary>
        /// Default Ctor required for MVC serialization
        /// </summary>
        // ReSharper disable once EmptyConstructor
        public BigDataScheduleModel()
        {

        }

        public string ScheduleId { get; set; }
        public string JobId { get; set; }
        public string OspScheduled { get; set; }
        public TimeSpan StartTime { get; set; }
        public double RepeatIntervalDays { get; set; }

        public string[] AvailableOsps { get; set; }
    }
}