using Services;
using Services.Interfaces;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameSceneContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InputService>(Lifetime.Scoped).As<IInputService>();
        }
    }
}
