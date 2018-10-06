using Acw.DynamicProxy;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Acw.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            await new AcwInterceptionTestBase<UnitTest1>().Should_Intercept_Async_Method_Without_Return_Value();
        }
    }
}
