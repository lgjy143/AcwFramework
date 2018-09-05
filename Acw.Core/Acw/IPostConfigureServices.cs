using Acw.Core.Acw.Modularity;

namespace Acw.Core.Acw
{
    public interface IPostConfigureServices
    {
        void PostConfigureServices(ServiceConfigurationContext context);
    }
}
