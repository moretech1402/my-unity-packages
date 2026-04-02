using MC.Core.Events;

namespace MC.Core.Unity
{
    public class CoreServicesInstaller : ServiceInstaller
    {
        protected override void Install()
        {
            Register(GlobalEventBus.Instance);
        }
    }
}
