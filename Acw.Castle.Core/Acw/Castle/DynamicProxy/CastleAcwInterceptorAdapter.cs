using Acw.DynamicProxy;
using Acw.Threading;
using Castle.DynamicProxy;
using System.Threading.Tasks;

namespace Acw.Castle.DynamicProxy
{
    class CastleAcwInterceptorAdapter<TInterceptor> : IInterceptor
        where TInterceptor : IAcwInterceptor
    {
        private readonly TInterceptor _acwInterceptor;

        public CastleAcwInterceptorAdapter(TInterceptor acwInterceptor)
        {
            _acwInterceptor = acwInterceptor;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            if (method.IsAsync())
            {
                InterceptAsyncMethod(invocation);
            }
            else
            {
                InterceptSyncMethod(invocation);
            }
        }

        private void InterceptAsyncMethod(IInvocation invocation)
        {
            if (invocation.Method.ReturnType == typeof(Task))
            {
                invocation.ReturnValue = _acwInterceptor.InterceptAsync(new CastleAcwMethodInvocationAdapter(invocation));
            }
            else
            {
                var interceptResult = _acwInterceptor.InterceptAsync(new CastleAcwMethodInvocationAdapter(invocation));
                var actualReturnValue = invocation.ReturnValue;
                invocation.ReturnValue = InternalAsyncHelper.CallAwaitTaskWithPreActionAndPostActionAndFinallyAndGetResult(
                    invocation.Method.ReturnType.GenericTypeArguments[0],
                    () => actualReturnValue,
                    () => interceptResult
                );
            }
        }

        private void InterceptSyncMethod(IInvocation invocation)
        {
            _acwInterceptor.Intercept(new CastleAcwMethodInvocationAdapter(invocation));
        }
    }
}
