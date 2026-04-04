using MC.Core.Unity;
using IStatsFactory = MC.Core.Stats.IStatsFactory;

namespace MC.Game.Stats
{
    public class StatServicesInstall : ServiceInstaller
    {
        protected override void Install()
        {
            Register<IStatsFactory>(new StatsFactory());
        }
    }
}