using System.Threading.Tasks;

namespace Acw.DynamicProxy
{
    public interface IAcwInterceptor
    {
        void Intercept(IAcwMethodInvocation invocation);

        Task InterceptAsync(IAcwMethodInvocation invocation);
    }
}
