using Acw.DependencyInjection;

namespace Acw.Modularity
{
    public interface IAcwModule : ISingletonDependency
    {
        void ConfigureServices(ServiceConfigurationContext context);
    }
}
