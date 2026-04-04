using System.Collections.Generic;
using MC.Core.Stats;
using MC.Core.Stats.Calculation;
using MC.Core.Stats.Modifiers;

namespace MC.Game.Stats
{
    public class StatsHandler : IStatsHandler
    {
        private readonly Dictionary<StatId, Stat> _stats;

        public StatsHandler(Dictionary<StatId, Stat> stats)
        {
            _stats = stats;
        }

        public void AddModifier(StatId statId, IStatModifier modifier)
        {
            if (_stats.TryGetValue(statId, out var stat))
            {
                stat.AddModifier(modifier);
            }
        }

        public void RemoveModifier(StatId statId, IStatModifier modifier)
        {
            if (_stats.TryGetValue(statId, out var stat))
            {
                stat.RemoveModifier(modifier);
            }
        }

        public float Get(StatId statId, IStatCalculation calculation)
        {
            return !_stats.TryGetValue(statId, out var stat) ? 0f : calculation.Calculate(stat, this);
        }

        public Stat GetStat(StatId statId)
        {
            return _stats.TryGetValue(statId, out var stat) ? stat : null;
        }
    }
}