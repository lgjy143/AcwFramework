using System;
using System.Collections.Generic;

namespace Acw.Core.Acw.DependencyInjection
{
    public interface IOnServiceExposingContext
    {
        Type ImplementationType { get; }

        List<Type> ExposedTypes { get; }
    }
}
