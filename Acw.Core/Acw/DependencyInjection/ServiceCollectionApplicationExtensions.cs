using Acw.Modularity;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acw.DependencyInjection
{
    public static class ServiceCollectionApplicationExtensions
    {
        public static IAcwApplicationWithExternalServiceProvider AddApplication<TStartupModule>(
            [NotNull] this IServiceCollection services,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IAcwModule
        {
            return AcwApplicationFactory.Create<TStartupModule>(services, optionsAction);
        }

        public static IAcwApplicationWithExternalServiceProvider AddApplication(
            [NotNull] this IServiceCollection services,
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction = null)
        {
            return AcwApplicationFactory.Create(startupModuleType, services, optionsAction);
        }
    }
}
