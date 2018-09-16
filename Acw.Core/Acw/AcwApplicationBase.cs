using Acw.Core.Acw.DependencyInjection;
using Acw.Core.Acw.Internal;
using Acw.Core.Acw.Modularity;
using Acw.Core.Microsoft.Extensions;
using Acw.Core.Microsoft.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Acw.Core.Acw
{
    public abstract class AcwApplicationBase: IAcwApplication
    {
        [NotNull]
        public Type StartupModuleType { get; }

        public IServiceProvider ServiceProvider { get; private set; }

        public IServiceCollection Services { get; }

        public IReadOnlyList<IAcwModuleDescriptor> Modules { get; }

        internal AcwApplicationBase(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            [CanBeNull] Action<AcwApplicationCreationOptions> optionsAction)
        {
            Check.NotNull(startupModuleType, nameof(startupModuleType));
            Check.NotNull(services, nameof(services));

            StartupModuleType = startupModuleType;
            Services = services;

            services.TryAddObjectAccessor<IServiceProvider>();

            var options = new AcwApplicationCreationOptions(services);
            optionsAction?.Invoke(options);

            services.AddSingleton<IAcwApplication>(this);
            services.AddSingleton<IModuleContainer>(this);

            services.AddCoreServices();
            services.AddCoreAcwServices(this);

            Modules = LoadModules(services, options);
        }

        public virtual void Shutdown()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .ShutdownModules(new ApplicationShutdownContext(scope.ServiceProvider));
            }
        }

        public virtual void Dispose()
        {

        }

        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }

        protected virtual void InitializeModules()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .InitializeModules(new ApplicationInitializationContext(scope.ServiceProvider));
            }
        }

        private IReadOnlyList<IAcwModuleDescriptor> LoadModules(IServiceCollection services, AcwApplicationCreationOptions options)
        {
            return services
                .GetSingletonInstance<IModuleLoader>()
                .LoadModules(
                    services,
                    StartupModuleType,
                    options.PlugInSources
                );
        }
    }
}
