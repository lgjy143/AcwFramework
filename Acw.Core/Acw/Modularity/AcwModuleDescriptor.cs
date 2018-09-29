using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

namespace Acw.Modularity
{
    public class AcwModuleDescriptor : IAcwModuleDescriptor
    {
        public Type Type { get; }

        public Assembly Assembly { get; }

        public IAcwModule Instance { get; }

        public bool IsLoadedAsPlugIn { get; }

        public IReadOnlyList<IAcwModuleDescriptor> Dependencies => _dependencies.ToImmutableList();
        private readonly List<IAcwModuleDescriptor> _dependencies;

        public AcwModuleDescriptor(
           [NotNull] Type type,
           [NotNull] IAcwModule instance,
           bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));

            if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
            {
                throw new ArgumentException($"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
            }

            Type = type;
            Assembly = type.Assembly;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;

            _dependencies = new List<IAcwModuleDescriptor>();
        }

        public void AddDependency(IAcwModuleDescriptor descriptor)
        {
            _dependencies.AddIfNotContains(descriptor);
        }

        public override string ToString()
        {
            return $"[AcwModuleDescriptor {Type.FullName}]";
        }

    }
}
