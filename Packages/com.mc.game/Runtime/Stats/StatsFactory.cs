using System.Collections.Generic;
using MC.Core.Stats;
using MC.Core.Stats.Sources;
using MC.Game.Stats.Sources;

namespace MC.Game.Stats
{
    public class StatsFactory : IStatsFactory
    {
        public IStatsHandler Create(StatsContainerSo statsContainerSo)
        {
            Dictionary<StatId, Stat> map = new();
            foreach (var entry in statsContainerSo.Stats)
            {
                map[entry.Id] = new Stat(CreateSource(entry.Source, entry.Value));
            }
            return new StatsHandler(map);
        }

        private static IStatSource CreateSource(StatSourceSo definition, float value)
        {
            return definition switch
            {
                BaseStatSourceSo => new BaseStatSource(value),
                _ => definition.DefaultCreate()
            };
        }
    }
}
