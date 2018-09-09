namespace Acw.Core.Acw.Modularity
{
    public class ModuleLifecycleContributerBase : IModuleLifecycleContributer
    {
        public virtual void Initialize(ApplicationInitializationContext context, IAcwModule module)
        {
        }

        public virtual void Shutdown(ApplicationShutdownContext context, IAcwModule module)
        {
        }
    }
}
