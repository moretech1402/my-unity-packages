using System.Collections.Generic;
using MC.Core.Stats.Modifiers;

namespace MC.Core.Stats
{
    public interface IStatsHandler : IStatsProvider
    {
        Dictionary<StatId, Stat> Stats { get; }
        void AddModifier(StatModifierEntry entry);
        void AddModifiers(IEnumerable<StatModifierEntry> entries);
        public void RemoveModifier(StatModifierEntry entry);
        public void RemoveModifiers(StatModifierEntry[] entries);
    }

}
