using MC.Core.Stats;
using MC.Core.Stats.Modifiers;
using MC.Game.Stats.Modifiers;

namespace MC.Game.Stats
{
    public interface IStatsFactory
    {
        IStatsHandler Create(StatsContainerSo statsContainerSo);
        IStatModifier Create(StatModifierData data);
        IStatModifier[] Create(StatModifierData[] datas);
    }
}