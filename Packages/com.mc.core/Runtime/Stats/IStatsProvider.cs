using MC.Core.Stats.Calculation;

namespace MC.Core.Stats
{
    public interface IStatsProvider
    {
        float Get(StatId statId, IStatCalculation calculation);
    }
}