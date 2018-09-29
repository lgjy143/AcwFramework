using JetBrains.Annotations;

namespace Acw
{
    interface IOnApplicationShutdown
    {
        void OnApplicationShutdown([NotNull] ApplicationShutdownContext context);
    }
}
