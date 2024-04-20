using Glacier.MagicOnion;
using Glacier.VContainer;
using VContainer;
using VContainer.Unity;

namespace Glacier.Samples
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StreamingHubAdapter<FooStreamingHubAPI>>(Lifetime.Singleton, plainEntryPoint: true)
                .WithParameter("http://localhost:5157");
        }
    }
}