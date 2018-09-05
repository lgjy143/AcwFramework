using JetBrains.Annotations;

namespace Acw.Core.Acw
{
    public interface IOnPostApplicationInitialization
    {
        void OnPostApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
