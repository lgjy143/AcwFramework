using JetBrains.Annotations;
using System;

namespace Acw.Modularity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class DependsOnAttribute : Attribute, IDependedTypesProvider
    {
        [NotNull]
        public Type[] DependedTypes { get; }
        public DependsOnAttribute(params Type[] dependedTypes)
        {
            DependedTypes = dependedTypes ?? new Type[0];
        }

        public Type[] GetDependedTypes()
        {
            return DependedTypes;
        }
    }
}
