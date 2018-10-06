using System.Collections.Generic;

namespace Acw.TestBase.Logging
{
    public interface ICanLogOnObject
    {
        List<string> Logs { get; }
    }
}
