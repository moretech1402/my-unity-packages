using System.Collections.Generic;
using System.Linq;
using MC.Core.Stats;
using MC.Core.Stats.Modifiers;
using MC.Core.Stats.Sources;
using MC.Game.Stats.Modifiers;
using MC.Game.Stats.Sources;

namespace MC.Game.Stats
{
    public class StatsFactory : IStatsFactory
    {
        public IStatsHandler Create(IStatContainerDefinition statsContainer)
        {
            Dictionary<StatId, Stat> map = new();
            foreach (var entry in statsContainer.Stats)
            {
                map[entry.Id] = new Stat(CreateSource(entry.Source, entry.Value));
            }
            return new StatsHandler(map);
        }

        public StatModifierEntry Create(IStatModifierEntryDefinition entryData)
        {
            return new StatModifierEntry(entryData.StatId, entryData.DefaultModifierCreate());
        }

        public StatModifierEntry[] Create(IStatModifierEntryDefinition[] datas)
        {
            return datas.Select(Create).ToArray();
        }
        
        public StatModifierEntry[] CreateModifiers(IStatContainerDefinition container)
        {
            return new StatModifierEntry[] { }; // ...
        }

        private static IStatSource CreateSource(IStatSourceDefinition definition, float value)
        {
            return definition switch
            {
                BaseStatSourceSo => new BaseStatSource(value),
                _ => definition.DefaultCreate()
            };
        }
    }
}
