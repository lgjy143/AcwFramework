using JetBrains.Annotations;
using System;

namespace Acw.Modularity.PlugIns
{
    public interface IPlugInSource
    {
        [NotNull]
        Type[] GetModules();
    }
}
