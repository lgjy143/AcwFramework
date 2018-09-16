namespace Acw.Core.Acw.Modularity
{
    public class OnApplicationInitializationModuleLifecycleContributer : ModuleLifecycleContributerBase
    {
        public override void Initialize(ApplicationInitializationContext context, IAcwModule module)
        {
            (module as IOnApplicationInitialization)?.OnApplicationInitialization(context);
        }
    }

    public class OnApplicationShutdownModuleLifecycleContributer : ModuleLifecycleContributerBase
    {
        public override void Shutdown(ApplicationShutdownContext context, IAcwModule module)
        {
            (module as IOnApplicationShutdown)?.OnApplicationShutdown(context);
        }
    }

    public class OnPreApplicationInitializationModuleLifecycleContributer : ModuleLifecycleContributerBase
    {
        public override void Initialize(ApplicationInitializationContext context, IAcwModule module)
        {
            (module as IOnPreApplicationInitialization)?.OnPreApplicationInitialization(context);
        }
    }

    public class OnPostApplicationInitializationModuleLifecycleContributer : ModuleLifecycleContributerBase
    {
        public override void Initialize(ApplicationInitializationContext context, IAcwModule module)
        {
            (module as IOnPostApplicationInitialization)?.OnPostApplicationInitialization(context);
        }
    }
}
