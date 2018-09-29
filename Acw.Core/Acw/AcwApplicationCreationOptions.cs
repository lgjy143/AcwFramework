using Acw.Modularity.PlugIns;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Acw
{
    public class AcwApplicationCreationOptions
    {
        [NotNull]
        public IServiceCollection Services { get; }

        [NotNull]
        public PlugInSourceList PlugInSources { get; }

        public AcwApplicationCreationOptions([NotNull] IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            PlugInSources = new PlugInSourceList();
        }
    }
}