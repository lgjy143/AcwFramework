using Acw.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Acw.DynamicProxy
{
    public abstract class AcwInterceptionTestBase<TStartupModule> : AcwIntegratedTest<TStartupModule>
        where TStartupModule : IAcwModule
    {
        [Fact]
        public async Task Should_Intercept_Async_Method_Without_Return_Value()
        {
            //Arrange

            var target = ServiceProvider.GetService<SimpleInterceptionTargetClass>();

            //Act

            await target.DoItAsync();

            //Assert

            target.Logs.Count.ShouldBe(9);
            target.Logs[0].ShouldBe("SimpleAsyncInterceptor_InterceptAsync_BeforeInvocation");
            target.Logs[1].ShouldBe("SimpleSyncInterceptor_Intercept_BeforeInvocation");
            target.Logs[2].ShouldBe("SimpleAsyncInterceptor2_InterceptAsync_BeforeInvocation");
            target.Logs[3].ShouldBe("EnterDoItAsync");
            target.Logs[4].ShouldBe("MiddleDoItAsync");
            target.Logs[5].ShouldBe("ExitDoItAsync");
            target.Logs[6].ShouldBe("SimpleAsyncInterceptor2_InterceptAsync_AfterInvocation");
            target.Logs[7].ShouldBe("SimpleSyncInterceptor_Intercept_AfterInvocation");
            target.Logs[8].ShouldBe("SimpleAsyncInterceptor_InterceptAsync_AfterInvocation");
        }

        [Fact]
        public void Should_Intercept_Async_Method_Without_Return_Value1()
        {

        }
    }
}
