using MC.Core.Events;
using VContainer;
using VContainer.Unity;

namespace MC.Core
{
    public class CoreLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Registrar dependencias
            // Evnts
            builder.Register<IEventBus, EventBus>(Lifetime.Singleton);
        }
    }
}