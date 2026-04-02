using VContainer;
using VContainer.Unity;

namespace MC.Game.Stats
{
    public class StatsLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IStatsFactory, StatsFactory>(Lifetime.Singleton);
        }
    }
}