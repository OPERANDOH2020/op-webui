using System.Collections.Generic;
using System.Linq;
using eu.operando.core.bda.Model;

namespace Operando_AdministrationConsole.Models.PspAnalystModels
{
    public class BigDataScheduleModel : BdaSchedule
    {
        /// <summary>
        /// Default Ctor required for MVC serialization
        /// </summary>
        // ReSharper disable once EmptyConstructor
        public BigDataScheduleModel()
        {
            
        }

        public BigDataScheduleModel(Schedule schedule, IEnumerable<string> availableOsps, IEnumerable<Job> availableJobs)
            : base(schedule)
        {
            AvailableOsps = availableOsps.ToArray();
            AvailableJobs = availableJobs.Select(_ => new BdaJob(_)).ToList();
        }


        public string[] AvailableOsps { get; }
        public ICollection<BdaJob> AvailableJobs { get; }
    }
}