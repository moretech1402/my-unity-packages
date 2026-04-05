using System.Collections.Generic;
using MC.Core.Stats.Calculation;
using MC.Core.Stats.Modifiers;

namespace MC.Core.Stats
{
    public interface IStatsHandler
    {
        Dictionary<StatId, Stat> Stats { get; }
        float Get(StatId statId, IStatCalculation calculation);
        void AddModifier(StatId statId, IStatModifier modifier);
    }

}
