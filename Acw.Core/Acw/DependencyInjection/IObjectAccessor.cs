using JetBrains.Annotations;

namespace Acw.Core.Acw.DependencyInjection
{
    public interface IObjectAccessor<out T>
    {
        [CanBeNull]
        T Value { get; }
    }
}
