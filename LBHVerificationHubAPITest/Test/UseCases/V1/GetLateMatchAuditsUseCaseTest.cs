using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LBHVerificationHubAPI.Gateways.V1;
using LBHVerificationHubAPI.UseCases.V1;
using Moq;
using Xunit;

namespace LBHVerificationHubAPITest.Test.UseCases.V1
{
    public class GetLateMatchAuditsUseCaseTest
    {
        private readonly Mock<IClearCoreGateway> _clearCoreGateway;
        private readonly IGetLateMatchAuditsUseCase _classUnderTest;

        public GetLateMatchAuditsUseCaseTest()
        {
            _clearCoreGateway = new Mock<IClearCoreGateway>();
            var matchAudits = new List<string> {"NAME[xt ]ADDRESS[I]"};
            _clearCoreGateway.Setup(useCase => useCase.GetLateMatchAudits("NAME[xt ]ADDRESS[I]"))
                .ReturnsAsync(new List<string> {"Matched from: NAME( -at least one missing title) & ADDRESS(complete address)"});
            
            _classUnderTest = new GetLateMatchAuditsUseCase(_clearCoreGateway.Object);
        }

        [Fact]
        public async Task ExecuteAsync_GivenValidMatchAudits_ReturnsAppropriately()
        {
            var matchAudits = new List<string> {"NAME[xt ]ADDRESS[I]"};
            var expectedResult = new List<string> {"Matched from: NAME( -at least one missing title) & ADDRESS(complete address)"};

            var actualResult = await _classUnderTest.ExecuteAsync(matchAudits);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}