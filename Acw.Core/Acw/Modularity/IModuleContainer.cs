using JetBrains.Annotations;
using System.Collections.Generic;

namespace Acw.Modularity
{
    public interface IModuleContainer
    {
        [NotNull]
        IReadOnlyList<IAcwModuleDescriptor> Modules { get; }
    }
}
