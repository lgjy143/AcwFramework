﻿using Acw.Modularity.PlugIns;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Acw.Modularity
{
    public interface IModuleLoader
    {
        [NotNull]
        IAcwModuleDescriptor[] LoadModules(
            [NotNull] IServiceCollection services,
            [NotNull] Type startupModuleType,
            [NotNull] PlugInSourceList plugInSources
        );
    }
}
