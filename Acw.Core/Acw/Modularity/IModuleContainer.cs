using JetBrains.Annotations;
using System.Collections.Generic;

namespace Acw.Core.Acw.Modularity
{
    public interface IModuleContainer
    {
        [NotNull]
        IReadOnlyList<IAcwModuleDescriptor> Modules { get; }
    }
}
