using Microsoft.Extensions.Configuration;

namespace Acw.Core.Acw.Configuration
{
    public interface IConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
