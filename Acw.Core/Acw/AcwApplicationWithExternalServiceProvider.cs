using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acw.Core.Acw
{
    internal class AcwApplicationWithExternalServiceProvider : AcwApplicationBase, IAcwApplicationWithExternalServiceProvider
    {
        public AcwApplicationWithExternalServiceProvider(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction
            ) : base(
                startupModuleType,
                services,
                optionsAction)
        {
            services.AddSingleton<IAcwApplicationWithExternalServiceProvider>(this);
        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            SetServiceProvider(serviceProvider);

            InitializeModules();
        }
    }
}
