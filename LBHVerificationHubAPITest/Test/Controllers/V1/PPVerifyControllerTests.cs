using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentAssertions;
using LBHVerificationHubAPI.Controllers.V1;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Objects;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Castle.Core.Logging;
using LBHVerificationHubAPI.Boundary.V1;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.UseCases.V1;
using LBHVerificationHubAPI.UseCases.V1.Search;
using LBHVerificationHubAPITest.Helpers;
using Microsoft.Extensions.Logging;

namespace LBHVerificationHubAPITest.Test.Controllers.V1
{
    public class PPVerifyControllerTests
    {
        private readonly Mock<IVerifyUseCase> _verifyMock;
        private readonly Mock<ISaveVerdictUseCase> _saveVerdictMock;
        private readonly Mock<IRetrieveVerdictUseCase> _retrieveVerdictMock;
        private readonly Mock<IGetLateMatchAuditsUseCase> _getLateMatchAuditsMock;

        private readonly PPVerifyController _classUnderTest;
        private readonly Logger<PPVerifyController> _logger;

        public PPVerifyControllerTests()
        {
            _verifyMock = new Mock<IVerifyUseCase>();
            _saveVerdictMock = new Mock<ISaveVerdictUseCase>();
            _retrieveVerdictMock = new Mock<IRetrieveVerdictUseCase>();
            _getLateMatchAuditsMock = new Mock<IGetLateMatchAuditsUseCase>();

            _classUnderTest = new PPVerifyController(
                _verifyMock.Object,
                _saveVerdictMock.Object,
                _retrieveVerdictMock.Object,
                _getLateMatchAuditsMock.Object,
                _logger);

            _logger = new Logger<PPVerifyController>(new LoggerFactory());

            _verifyMock.Setup(
                    s => s.ExecuteAsync(It.IsAny<ParkingPermitVerificationRequest>(), CancellationToken.None))
                .ReturnsAsync(new ClearCoreResponse()
                );
        }

        [Fact]
        public async Task GivenValidRequest_WhenCallingVerify_ThenShouldReturn200()
        {
            var request = new ParkingPermitVerificationRequest();

            var response = await _classUnderTest.Verify(request).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
            var objectResult = response as ObjectResult;
            objectResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GivenValidRequest_WhenCallingVerify_ThenShouldReturnAPIResponse()
        {
            var request = new ParkingPermitVerificationRequest();

            var response = await _classUnderTest.Verify(request).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
            var objectResult = response as ObjectResult;
            var apiResponse = objectResult?.Value as APIResponse<ParkingPermitVerificationResponse>;
            apiResponse.Should().NotBeNull();
        }

        [Fact]
        public async Task GetVerdict_WithValidGuid_ReturnsVerifyResponse()
        {
            // Arrange
            var verdict = VerdictHelper.RandomVerdict();
            var verdictRequest = new VerdictRequest {Guid = verdict.VerdictId};

            _retrieveVerdictMock.Setup(s => s.ExecuteAsync(verdictRequest))
                .ReturnsAsync(new VerdictResponse {Verdict = verdict});
            
            //Act
            var response = await _classUnderTest.GetVerdict(verdictRequest.Guid);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
        }
    }
}