using System;

namespace Acw.Core.Acw.DependencyInjection
{
    public interface IExposedServiceTypesProvider
    {
        Type[] GetExposedServiceTypes(Type targetType);
    }
}
