using System.Collections.Generic;
using MC.Core.Stats;
using MC.Core.Stats.Calculation;
using MC.Core.Stats.Modifiers;
using MC.Core.Stats.Sources;

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
        
        public void AddModifier(StatModifierEntry entry)
        {
            GetOrCreateStat(entry.StatId)
                .AddModifier(entry.Modifier);
        }

        public void AddModifiers(IEnumerable<StatModifierEntry> entries)
        {
            foreach (var entry in entries)
            {
                AddModifier(entry);
            }
        }

        public void RemoveModifier(StatModifierEntry entry)
        {
            if (Stats.TryGetValue(entry.StatId, out var stat))
            {
                stat.RemoveModifier(entry.Modifier);
            }
        }
        
        public void RemoveModifiers(StatModifierEntry[] entries)
        {
            foreach (var entry in entries)
            {
                RemoveModifier(entry);
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
        
        private Stat GetOrCreateStat(StatId statId)
        {
            if (Stats.TryGetValue(statId, out var stat))
                return stat;
            
            var newStat = new Stat(new BaseStatSource(0f));
            Stats[statId] = newStat;
            return newStat;
        }
    }
}