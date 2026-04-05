using MC.Core.Stats;
using MC.Game.Stats.Modifiers;

namespace MC.Game.Stats
{
    public interface IStatsFactory
    {
        IStatsHandler Create(StatsContainerSo statsContainerSo);
        StatModifierEntry Create(StatModifierEntryData entryData);
        StatModifierEntry[] Create(StatModifierEntryData[] datas);
    }
}