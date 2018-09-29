using JetBrains.Annotations;
using System;

namespace Acw
{
    public  interface IAcwApplicationWithExternalServiceProvider : IAcwApplication
    {
        void Initialize([NotNull] IServiceProvider serviceProvider);
    }
}
