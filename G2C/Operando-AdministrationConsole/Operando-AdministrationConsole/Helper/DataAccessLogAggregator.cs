using System.Collections.Generic;
using System.Linq;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsole.Helper
{
    public class DataAccessLogAggregator
    {
        public IEnumerable<DataAccessLogModel> Aggregate(IEnumerable<DataAccessLogModel> models)
        {
            var groupedByRequester = models.GroupBy(m => m.RequesterId);
            var aggregated = groupedByRequester.SelectMany(AggregateSameRequester);
            var sorted = aggregated.OrderBy(m => m.LogDateEnd ?? m.LogDateStart);
            return sorted;
        }

        private IEnumerable<DataAccessLogModel> AggregateSameRequester(IEnumerable<DataAccessLogModel> models)
        {
            var groupedByAggregatable = GroupByAggregatable(models);
            var aggregated = groupedByAggregatable.Select(g => new DataAccessLogModel(g.ToList()));
            return aggregated;
        }

        private IEnumerable<IList<DataAccessLogModel>> GroupByAggregatable(IEnumerable<DataAccessLogModel> models)
        {
            var sorted = models.OrderBy(m => m.LogDateStart).ToList();

            var first = sorted.First();
            var remaining = sorted.Skip(1);

            var currentGroup = new List<DataAccessLogModel> {first};
            var currentStart = first.LogDateStart;
            var currentGranted = new SortedSet<string>();
            foreach (var field in first.GrantedFields)
            {
                currentGranted.Add(field);
            }
            var currentDenied = new SortedSet<string>();
            foreach (var field in first.DeniedFields)
            {
                currentDenied.Add(field);
            }

            foreach (var model in remaining)
            {

                if ((currentStart.Day != model.LogDateStart.Day) ||
                    (model.DeniedFields.Any(f => currentGranted.Contains(f))) ||
                    (model.GrantedFields.Any(f => currentDenied.Contains(f))))
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