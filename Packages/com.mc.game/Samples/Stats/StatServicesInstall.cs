using MC.Core.Stats;
using MC.Core.Unity;
using UnityEngine;

namespace MC.Game.Stats
{
    public class StatServicesInstall : ServiceInstaller
    {
        [SerializeField] private StatDefinitionSo[] _statDefinitions;
        
        protected override void Install()
        {
            Register<IStatsFactory>(new StatsFactory());
            Register<IStatCatalog>(new StatCatalog(_statDefinitions));
        }
    }
}