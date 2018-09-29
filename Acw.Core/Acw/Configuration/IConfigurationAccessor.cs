using Microsoft.Extensions.Configuration;

namespace Acw.Configuration
{
    public interface IConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
