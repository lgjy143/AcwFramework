using Acw.Core.Acw.Modularity;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acw.Core.Acw
{
    public class AcwApplicationFactory
    {
        public static IAcwApplicationWithInternalServiceProvider Create<TStartupModule>(
          [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction = null)
          where TStartupModule : IAcwModule
        {
            return Create(typeof(TStartupModule), optionsAction);
        }

        public static IAcwApplicationWithInternalServiceProvider Create(
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction = null)
        {
            return new AcwApplicationWithInternalServiceProvider(startupModuleType, optionsAction);
        }

        public static IAcwApplicationWithExternalServiceProvider Create<TStartupModule>(
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IAcwModule
        {
            return Create(typeof(TStartupModule), services, optionsAction);
        }

        public static IAcwApplicationWithExternalServiceProvider Create(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction = null)
        {
            return new AcwApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
        }
    }
}
