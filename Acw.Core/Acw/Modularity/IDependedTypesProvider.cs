using JetBrains.Annotations;
using System;

namespace Acw.Modularity
{
    public interface IDependedTypesProvider
    {
        [NotNull]
        Type[] GetDependedTypes();
    }
}
