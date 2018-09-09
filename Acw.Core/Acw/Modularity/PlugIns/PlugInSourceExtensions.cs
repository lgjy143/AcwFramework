using JetBrains.Annotations;
using System;
using System.Linq;

namespace Acw.Core.Acw.Modularity.PlugIns
{
    public static class PlugInSourceExtensions
    {
        [NotNull]
        public static Type[] GetModulesWithAllDependencies([NotNull] this IPlugInSource plugInSource)
        {
            Check.NotNull(plugInSource, nameof(plugInSource));

            return plugInSource
                .GetModules()
                .SelectMany(AcwModuleHelper.FindAllModuleTypes)
                .Distinct()
                .ToArray();
        }
    }
}
