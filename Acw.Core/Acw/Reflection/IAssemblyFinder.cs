﻿using System.Collections.Generic;
using System.Reflection;

namespace Acw.Core.Acw.Reflection
{
    /// <summary>
    /// Used to get assemblies in the application.
    /// It may not return all assemblies, but those are related with modules.
    /// </summary>
    public interface IAssemblyFinder
    {
        IReadOnlyList<Assembly> Assemblies { get; }
    }
}
