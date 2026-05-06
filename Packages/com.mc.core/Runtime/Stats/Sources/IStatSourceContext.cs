namespace MC.Core.Stats.Sources
{
    public interface IStatSourceContext
    {
        IStatsHandler StatsHandler { get; }
    }
}