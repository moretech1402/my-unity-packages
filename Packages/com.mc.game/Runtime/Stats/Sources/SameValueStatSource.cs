using MC.Core.Stats;
using MC.Core.Stats.Sources;

namespace MC.Game.Stats.Sources
{
    public class SameValueStatSource : IStatSource
    {
        private readonly StatId _statIdRef;

        public SameValueStatSource(StatId statIdRef)
        {
            _statIdRef = statIdRef;
        }
        
        public float GetValue(IStatSourceContext context)
        {
            return context.StatsHandler.Get(_statIdRef, StatCalculationCatalog.Final);
        }
    }
}