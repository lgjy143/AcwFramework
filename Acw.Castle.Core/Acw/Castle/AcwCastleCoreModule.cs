using Acw.Castle.DynamicProxy;
using Acw.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Acw.Castle
{
    public class AcwCastleCoreModule : AcwModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient(typeof(CastleAcwInterceptorAdapter<>));
        }
    }
}
