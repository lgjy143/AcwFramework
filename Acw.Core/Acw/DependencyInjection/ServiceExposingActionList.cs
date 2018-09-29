using System;
using System.Collections.Generic;

namespace Acw.DependencyInjection
{
    public class ServiceExposingActionList : List<Action<IOnServiceExposingContext>>
    {

    }
}
