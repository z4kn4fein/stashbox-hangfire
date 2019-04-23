using Stashbox;
using Stashbox.Hangfire;
using Stashbox.Utils;

namespace Hangfire
{
    public static class GlobalConfigurationExtensions
    {
        public static IGlobalConfiguration<StashboxJobActivator> UseStashboxActivator(
            this IGlobalConfiguration configuration,
            IDependencyResolver container)
        {
            Shield.EnsureNotNull(container, nameof(container));

            return configuration.UseActivator(new StashboxJobActivator(container));
        }
    }
}
