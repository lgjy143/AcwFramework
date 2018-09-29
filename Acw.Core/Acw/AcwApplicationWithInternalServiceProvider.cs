using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acw
{
    public class AcwApplicationWithInternalServiceProvider : AcwApplicationBase, IAcwApplicationWithInternalServiceProvider
    {
        public IServiceScope ServiceScope { get; private set; }

        public AcwApplicationWithInternalServiceProvider(
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction
            ) : this(
            startupModuleType,
            new ServiceCollection(),
            optionsAction)
        {

        }

        private AcwApplicationWithInternalServiceProvider(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction
            ) : base(
                startupModuleType,
                services,
                optionsAction)
        {
            Services.AddSingleton<IAcwApplicationWithInternalServiceProvider>(this);
        }

        public void Initialize()
        {
            ServiceScope = Services.BuildServiceProviderFromFactory().CreateScope();
            SetServiceProvider(ServiceScope.ServiceProvider);

            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
            ServiceScope.Dispose();
        }
    }
}
