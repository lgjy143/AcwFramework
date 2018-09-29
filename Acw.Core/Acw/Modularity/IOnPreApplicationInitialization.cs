using JetBrains.Annotations;

namespace Acw.Modularity
{
    public interface IOnPreApplicationInitialization
    {
        void OnPreApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
