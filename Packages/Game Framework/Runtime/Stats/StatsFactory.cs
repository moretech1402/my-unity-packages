using MC.Core.Stats;
using MC.Core.Stats.Sources;
using MC.Game.Stats.Sources;

namespace MC.Game.Stats
{
    public interface IStatsFactory
    {
        StatsHandler Create(StatsContainerSO statsContainerSO);
    }

    public class StatsFactory : IStatsFactory
    {
        public StatsHandler Create(StatsContainerSO statsContainerSO)
        {
            return new(new()
            {
                {StatsCatalog.Health, new(new BaseStatSource(statsContainerSO.Health) )},
                {StatsCatalog.Mana, new(new BaseStatSource(statsContainerSO.Mana))},
                {StatsCatalog.Stamina, new(new BaseStatSource(statsContainerSO.Stamina))},
                {StatsCatalog.Strength, new(new BaseStatSource(statsContainerSO.Strength))},
                {StatsCatalog.Speed, new(new BaseStatSource(statsContainerSO.Speed))},
                {StatsCatalog.Attack, new(new AttackStatSource())},
                {StatsCatalog.Defense, new(new DefenseStatSource())}
            });
        }
    }
}
