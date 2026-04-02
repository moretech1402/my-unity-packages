namespace MC.Core.Stats.Sources
{
    public interface IStatSource
    {
        float GetValue(IStatsHandler stats);
    }

}
