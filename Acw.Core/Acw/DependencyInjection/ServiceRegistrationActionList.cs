using System;
using System.Collections.Generic;

namespace Acw.DependencyInjection
{
    public class ServiceRegistrationActionList : List<Action<IOnServiceRegistredContext>>
    {

    }
}
