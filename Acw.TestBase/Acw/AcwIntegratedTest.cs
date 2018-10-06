using Acw.DependencyInjection;
using Acw.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acw
{
    public abstract class AcwIntegratedTest<TStartupModule> : AcwTestBaseWithServiceProvider, IDisposable
       where TStartupModule : IAcwModule
    {
        protected IAcwApplication Application { get; }

        protected override IServiceProvider ServiceProvider => Application.ServiceProvider;

        protected IServiceProvider RootServiceProvider { get; }

        protected IServiceScope TestServiceScope { get; }

        protected AcwIntegratedTest()
        {
            var services = CreateServiceCollection();

            BeforeAddApplication(services);

            var application = services.AddApplication<TStartupModule>(SetAcwApplicationCreationOptions);
            Application = application;

            AfterAddApplication(services);

            RootServiceProvider = CreateServiceProvider(services);
            TestServiceScope = RootServiceProvider.CreateScope();

            application.Initialize(TestServiceScope.ServiceProvider);
        }

        protected virtual IServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }

        protected virtual void BeforeAddApplication(IServiceCollection services)
        {

        }

        protected virtual void SetAcwApplicationCreationOptions(AcwApplicationCreationOptions options)
        {

        }

        protected virtual void AfterAddApplication(IServiceCollection services)
        {

        }

        protected virtual IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            return services.BuildServiceProviderFromFactory();
        }

        public virtual void Dispose()
        {
            Application.Shutdown();
            TestServiceScope.Dispose();
            Application.Dispose();
        }
    }
}
