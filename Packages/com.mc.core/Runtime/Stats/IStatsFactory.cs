namespace MC.Core.Stats
{
    public interface IStatsFactory
    {
        IStatsHandler Create(StatsContainerSo statsContainerSo);
    }
}