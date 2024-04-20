using VContainer;

namespace Glacier.VContainer
{
    public static class ContainerBuilderExtensions
    {
        public static RegistrationBuilder Register<T>(this IContainerBuilder builder, Lifetime lifetime, bool plainEntryPoint)
        {
            if (plainEntryPoint)
            {
                builder.RegisterBuildCallback(resolver => resolver.Resolve<T>());
            }

            return builder.Register<T>(lifetime);
        }

        public static RegistrationBuilder Register<TInterface, TImpl>(this IContainerBuilder builder, Lifetime lifetime,
            bool plainEntryPoint) where TImpl : TInterface
        {
            if (plainEntryPoint)
            {
                builder.RegisterBuildCallback(resolver => resolver.Resolve<TInterface>());
            }

            return builder.Register<TInterface, TImpl>(lifetime);
        }
    }
}