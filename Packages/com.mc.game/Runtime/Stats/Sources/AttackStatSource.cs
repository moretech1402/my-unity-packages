using MC.Core.Stats;
using MC.Core.Stats.Sources;

namespace MC.Game.Stats.Sources
{
    public class AttackStatSource : IStatSource
    {
        public float GetValue(IStatsHandler stats)
        {
            return stats.Get(StatsCatalog.Strength, StatCalculationCatalog.Final);
        }
    }
}