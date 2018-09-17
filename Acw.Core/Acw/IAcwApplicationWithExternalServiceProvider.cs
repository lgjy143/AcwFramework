using JetBrains.Annotations;
using System;

namespace Acw.Core.Acw
{
    public  interface IAcwApplicationWithExternalServiceProvider : IAcwApplication
    {
        void Initialize([NotNull] IServiceProvider serviceProvider);
    }
}
