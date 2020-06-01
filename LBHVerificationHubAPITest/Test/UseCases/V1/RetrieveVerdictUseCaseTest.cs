using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LBHVerificationHubAPI.Boundary.V1;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.Gateways.V1;
using LBHVerificationHubAPI.UseCases.V1;
using Moq;
using Xunit;

namespace LBHVerificationHubAPITest.Test.UseCases.V1
{
    public class RetrieveVerdictUseCaseTests
    {
        private readonly Mock<IVerdictDbGateway> _verdictDbGateway;
        private readonly IRetrieveVerdictUseCase _classUnderTest;

        public RetrieveVerdictUseCaseTests()
        {
            _verdictDbGateway = new Mock<IVerdictDbGateway>();
            _verdictDbGateway.Setup(gateway => gateway.FetchVerdict(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<Verdict>());
            _classUnderTest = new RetrieveVerdictUseCase(_verdictDbGateway.Object);
        }

        [Fact]
        public async Task ExecuteAsync_GivenRequestWithValidGuid_ReturnsExpectedVerdict()
        {
            var verdictRequest = new VerdictRequest
            {
                Guid = Guid.NewGuid()
            };
            var actualResult = await _classUnderTest.ExecuteAsync(verdictRequest);

            _verdictDbGateway.Verify(gateway => gateway.FetchVerdict(It.IsAny<Guid>()), Times.Once);
            actualResult.Should().BeOfType<VerdictResponse>();
        }
    }
}
