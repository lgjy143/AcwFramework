using System.Threading.Tasks;

namespace Acw.DynamicProxy
{
    public abstract class AcwInterceptor: IAcwInterceptor
    {
        public abstract void Intercept(IAcwMethodInvocation invocation);

        public virtual Task InterceptAsync(IAcwMethodInvocation invocation)
        {
            Intercept(invocation);
            return Task.CompletedTask;
        }
    }
}
