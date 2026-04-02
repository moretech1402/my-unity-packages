using System.Collections.Generic;
using MC.Core.Stats;
using MC.Core.Stats.Sources;
using MC.Game.Stats.Sources;

namespace MC.Game.Stats
{
    public interface IStatsFactory
    {
        StatsHandler Create(StatsContainerSo statsContainerSo);
    }

    public class StatsFactory : IStatsFactory
    {
        public StatsHandler Create(StatsContainerSo statsContainerSo)
        {
            return new StatsHandler(new Dictionary<StatId, Stat>
            {
                {StatsCatalog.Health, new Stat(new BaseStatSource(statsContainerSo.health))},
                {StatsCatalog.Mana, new Stat(new BaseStatSource(statsContainerSo.mana))},
                {StatsCatalog.Stamina, new Stat(new BaseStatSource(statsContainerSo.stamina))},
                {StatsCatalog.Strength, new Stat(new BaseStatSource(statsContainerSo.strength))},
                {StatsCatalog.Speed, new Stat(new BaseStatSource(statsContainerSo.speed))},
                {StatsCatalog.Attack, new Stat(new AttackStatSource())},
                {StatsCatalog.Defense, new Stat(new DefenseStatSource())}
            });
        }
    }
}
