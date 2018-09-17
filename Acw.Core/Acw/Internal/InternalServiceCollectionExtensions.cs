using Acw.Core.Acw.Configuration;
using Acw.Core.Acw.Modularity;
using Acw.Core.Acw.Reflection;
using Acw.Core.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Acw.Core.Acw.Internal
{
    internal static class InternalServiceCollectionExtensions
    {
        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddLocalization();
        }

        internal static void AddCoreAcwServices(this IServiceCollection services, IAcwApplication AcwApplication)
        {
            var moduleLoader = new ModuleLoader();
            var assemblyFinder = new AssemblyFinder(AcwApplication);
            var typeFinder = new TypeFinder(assemblyFinder);

            services.TryAddSingleton<IConfigurationAccessor>(DefaultConfigurationAccessor.Empty);
            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);

            services.AddAssemblyOf<IAcwApplication>();

            services.Configure<ModuleLifecycleOptions>(options =>
            {
                options.Contributers.Add<OnPreApplicationInitializationModuleLifecycleContributer>();
                options.Contributers.Add<OnApplicationInitializationModuleLifecycleContributer>();
                options.Contributers.Add<OnPostApplicationInitializationModuleLifecycleContributer>();
                options.Contributers.Add<OnApplicationShutdownModuleLifecycleContributer>();
            });
        }
    }
}
