using Acw.Core.Acw.Modularity;

namespace Acw.Core.Acw
{
    public interface IPreConfigureServices
    {
        void PreConfigureServices(ServiceConfigurationContext context);
    }
}
