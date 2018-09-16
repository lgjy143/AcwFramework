using System;
using System.Collections.Generic;

namespace Acw.Core.Acw.DependencyInjection
{
    public class ServiceExposingActionList : List<Action<IOnServiceExposingContext>>
    {

    }
}
