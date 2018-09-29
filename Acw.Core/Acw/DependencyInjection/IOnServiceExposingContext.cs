using System;
using System.Collections.Generic;

namespace Acw.DependencyInjection
{
    public interface IOnServiceExposingContext
    {
        Type ImplementationType { get; }

        List<Type> ExposedTypes { get; }
    }
}
