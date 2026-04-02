using MC.Core.Stats;
using MC.Core.Stats.Sources;

namespace MC.Game.Stats.Sources
{
    public class DefenseStatSource : IStatSource
    {
        public float GetValue(IStatsHandler stats)
        {
            return 1;
        }
    }
}
