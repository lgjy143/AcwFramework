using JetBrains.Annotations;
using System;

namespace Acw.Core.Acw.Modularity.PlugIns
{
    public interface IPlugInSource
    {
        [NotNull]
        Type[] GetModules();
    }
}
