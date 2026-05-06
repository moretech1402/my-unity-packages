using MC.Core.Stats;
using MC.Core.Stats.Sources;

namespace Features.Game.Stats.Sources
{
    public class BasicStatSourceContext : IStatSourceContext
    {
        public IStatsHandler StatsHandler { get; }
        
        public BasicStatSourceContext(IStatsHandler statsHandler)
        {
            StatsHandler = statsHandler;
        }
    }
}