using System;
using System.Collections.Generic;
using System.Reflection;

namespace Acw.Modularity
{
    public interface IAcwModuleDescriptor
    {
        Type Type { get; }

        Assembly Assembly { get; }

        IAcwModule Instance { get; }

        bool IsLoadedAsPlugIn { get; }

        IReadOnlyList<IAcwModuleDescriptor> Dependencies { get; }
    }
}
