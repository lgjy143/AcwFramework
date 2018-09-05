using JetBrains.Annotations;

namespace Acw.Core.Acw
{
    public interface IOnApplicationInitialization
    {
        void OnApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
