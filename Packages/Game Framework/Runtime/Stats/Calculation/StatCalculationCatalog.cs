using MC.Core.Stats.Calculation;
using MC.Game.Stats.Calculation;

namespace MC.Game.Stats
{
    public static class StatCalculationCatalog
    {
        public static readonly IStatCalculation Final = new FinalStatCalculation();
    }

}
