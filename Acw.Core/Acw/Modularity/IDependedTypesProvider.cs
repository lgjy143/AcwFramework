using JetBrains.Annotations;
using System;

namespace Acw.Core.Acw.Modularity
{
    public interface IDependedTypesProvider
    {
        [NotNull]
        Type[] GetDependedTypes();
    }
}
