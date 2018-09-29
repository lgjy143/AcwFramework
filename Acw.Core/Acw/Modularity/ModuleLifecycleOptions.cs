using Acw.Collections;

namespace Acw.Modularity
{
    public class ModuleLifecycleOptions
    {
        public ITypeList<IModuleLifecycleContributer> Contributers { get; }

        public ModuleLifecycleOptions()
        {
            Contributers = new TypeList<IModuleLifecycleContributer>();
        }
    }
}
