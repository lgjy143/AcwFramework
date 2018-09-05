using JetBrains.Annotations;

namespace Acw.Core.Acw.Modularity
{
    public interface IModuleManager
    {
        void InitializeModules([NotNull] ApplicationInitializationContext context);
        
        void ShutdownModules([NotNull] ApplicationShutdownContext context);
    }
}
