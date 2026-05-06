using MC.Core.Events;
using MC.Core.Logging;
using MC.Core.Unity.Logging;
using UnityEngine;

namespace MC.Core.Unity
{
    public class CoreServicesInstaller : ServiceInstaller
    {
        [SerializeField] private UnityLogger _logSink;
        
        protected override void Install()
        {
            Register(GlobalEventBus.Instance);
            Register<ILogSink>(_logSink);
        }
    }
}
