using System.Collections.Generic;
using MC.Core.Stats;

namespace MC.Game.Stats
{
    public class StatsFactory : IStatsFactory
    {
        public IStatsHandler Create(StatsContainerSo statsContainerSo)
        {
            Dictionary<StatId, Stat> map = new();
            foreach (var entry in statsContainerSo.Stats)
            {
                map[entry.Id] = entry.Stat.Create();
            }
            return new StatsHandler(map);
        }
    }
}
