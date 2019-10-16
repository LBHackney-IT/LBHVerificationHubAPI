using Xunit;
using LBHVerificationHubAPI.UseCases.V1;

namespace LBHVerificationHubAPITest.Test.UseCases.V1
{
    public class ThrowOpsErrorUseCaseTest
    {
        [Fact]
        public void ThrowsTestOpsErrorException()
        {
            TestOpsErrorException ex = Assert.Throws<TestOpsErrorException>(
                delegate { ThrowOpsErrorUseCase.Execute(); });

            Assert.Equal(ex.Message, "This is a test exception to test our integrations");
        }
    }
}