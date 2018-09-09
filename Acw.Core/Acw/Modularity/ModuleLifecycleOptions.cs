using Acw.Core.Acw.Collections;

namespace Acw.Core.Acw.Modularity
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
