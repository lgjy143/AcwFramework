using Acw.Core.Acw.DependencyInjection;
using JetBrains.Annotations;

namespace Acw.Core.Acw.Modularity
{
    public interface IModuleLifecycleContributer : ISingletonDependency
    {
        void Initialize([NotNull] ApplicationInitializationContext context, [NotNull] IAcwModule module);

        void Shutdown([NotNull] ApplicationShutdownContext context, [NotNull] IAcwModule module);
    }
}
