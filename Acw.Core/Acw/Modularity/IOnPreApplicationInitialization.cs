using JetBrains.Annotations;

namespace Acw.Core.Acw.Modularity
{
    public interface IOnPreApplicationInitialization
    {
        void OnPreApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
