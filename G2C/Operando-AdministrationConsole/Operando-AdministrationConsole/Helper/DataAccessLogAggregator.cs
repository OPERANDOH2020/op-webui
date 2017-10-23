using System;
using System.Collections.Generic;
using System.Linq;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsole.Helper
{
    public class DataAccessLogAggregator
    {
        public IEnumerable<DataAccessLogModel> Aggregate(IEnumerable<DataAccessLogModel> models)
        {
            var groupedByRequesterAndOsp = models
                .GroupBy(m => m.RequesterId)
                .SelectMany(g => g.GroupBy(m => m.OspId));
            var aggregated = groupedByRequesterAndOsp.SelectMany(AggregateModels);
            var sorted = aggregated.OrderBy(m => m.LogDateEnd ?? m.LogDateStart);
            return sorted;
        }

        private IEnumerable<DataAccessLogModel> AggregateModels(IEnumerable<DataAccessLogModel> models)
        {
            var groupedByAggregatable = SplitByDayAndClashingRequests(models);
            var aggregated = groupedByAggregatable
                .Select(g => new DataAccessLogModel(
                    "", 
                    g.Select(l => l.RequesterId).Distinct().Single(),
                    g.SelectMany(l => l.GrantedFields).Distinct(), 
                    g.SelectMany(l => l.DeniedFields).Distinct(),
                    g.Min(l => l.LogDateStart),
                    g.Count > 1 ? (DateTime?) g.Max(m => m.LogDateStart) : null));
            return aggregated;
        }

        private IEnumerable<IList<DataAccessLogModel>> SplitByDayAndClashingRequests(IEnumerable<DataAccessLogModel> models)
        {
            var sorted = models.OrderBy(m => m.LogDateStart).ToList();

            var currentGroup = new List<DataAccessLogModel>();
            var currentStart = sorted.FirstOrDefault()?.LogDateStart ?? DateTime.MinValue;
            var currentGranted = new SortedSet<string>();
            var currentDenied = new SortedSet<string>();

            foreach (var model in sorted)
            {
                var shouldStartNewGroup =
                    (currentStart.Day != model.LogDateStart.Day) ||
                    (model.DeniedFields.Any(f => currentGranted.Contains(f))) ||
                    (model.GrantedFields.Any(f => currentDenied.Contains(f)));


                if (shouldStartNewGroup)
                {
                    yield return currentGroup;
                    currentStart = model.LogDateStart;
                    currentGroup = new List<DataAccessLogModel>();
                    currentGranted.Clear();
                    currentDenied.Clear();
                }
                currentGroup.Add(model);
                foreach (var field in model.GrantedFields)
                {
                    currentGranted.Add(field);
                }
                foreach (var field in model.DeniedFields)
                {
                    currentDenied.Add(field);
                }

            }

            yield return currentGroup;
        }
    }
}