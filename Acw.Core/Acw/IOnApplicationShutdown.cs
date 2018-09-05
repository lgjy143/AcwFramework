using JetBrains.Annotations;

namespace Acw.Core.Acw
{
    interface IOnApplicationShutdown
    {
        void OnApplicationShutdown([NotNull] ApplicationShutdownContext context);
    }
}
