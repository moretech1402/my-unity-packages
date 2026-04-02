namespace MC.Core.Stats.Calculation
{
    public interface IStatCalculation
    {
        float Calculate(Stat stat, IStatsHandler context);
    }
}