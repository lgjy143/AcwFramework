using JetBrains.Annotations;

namespace Acw
{
    public interface IOnApplicationInitialization
    {
        void OnApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
