using MC.Core.Stats;
using MC.Core.Stats.Modifiers;
using MC.Game.Stats.Modifiers;

namespace MC.Game.Stats
{
    public interface IStatsFactory
    {
        IStatsHandler Create(IStatContainerDefinition statsContainer);
        StatModifierEntry Create(IStatModifierEntryDefinition entryData);
        StatModifierEntry[] Create(IStatModifierEntryDefinition[] datas);
    }
}