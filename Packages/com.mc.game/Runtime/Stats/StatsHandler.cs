using System.Collections.Generic;
using MC.Core.Stats;
using MC.Core.Stats.Calculation;
using MC.Core.Stats.Modifiers;

namespace MC.Game.Stats
{
    public class StatsHandler : IStatsHandler
    {
        public Dictionary<StatId, Stat> Stats { get; }

        public StatsHandler(Dictionary<StatId, Stat> stats)
        {
            Stats = stats;
        }

        public void AddModifier(StatId statId, IStatModifier modifier)
        {
            if (Stats.TryGetValue(statId, out var stat))
            {
                stat.AddModifier(modifier);
            }
        }

        public void RemoveModifier(StatId statId, IStatModifier modifier)
        {
            if (Stats.TryGetValue(statId, out var stat))
            {
                stat.RemoveModifier(modifier);
            }
        }

        public float Get(StatId statId, IStatCalculation calculation)
        {
            var stat = GetStat(statId);
            return stat != null ? calculation.Calculate(stat, this) : 0f;
        }

        private Stat GetStat(StatId statId)
        {
            return Stats.GetValueOrDefault(statId);
        }
    }
}