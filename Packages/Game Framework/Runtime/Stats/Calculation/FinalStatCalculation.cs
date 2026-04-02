using MC.Core.Stats;
using MC.Core.Stats.Calculation;

namespace MC.Game.Stats.Calculation
{
    public class FinalStatCalculation : IStatCalculation
    {
        public float Calculate(Stat stat, IStatsHandler context)
        {
            var finalValue = stat.Source.GetValue(context);
            foreach (var modifier in stat.Modifiers)
            {
                finalValue = modifier.Apply(finalValue);
            }
            return finalValue;
        }
    }

}
