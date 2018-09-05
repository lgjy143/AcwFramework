using Acw.Core.Acw.DependencyInjection;

namespace Acw.Core.Acw.Modularity
{
    public interface IAcwModule : ISingletonDependency
    {
        void ConfigureServices(ServiceConfigurationContext context);
    }
}
