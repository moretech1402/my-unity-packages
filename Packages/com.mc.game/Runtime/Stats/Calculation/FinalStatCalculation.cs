using System.Linq;
using Features.Game.Stats.Sources;
using MC.Core.Stats;
using MC.Core.Stats.Calculation;

namespace MC.Game.Stats.Calculation
{
    public class FinalStatCalculation : IStatCalculation
    {
        public float Calculate(Stat stat, IStatsHandler context)
        {
            var finalValue = stat.Source.GetValue(new BasicStatSourceContext(context));
            return stat.Modifiers
                .Aggregate(finalValue, (current, modifier) => modifier.Apply(current));
        }
    }

}
