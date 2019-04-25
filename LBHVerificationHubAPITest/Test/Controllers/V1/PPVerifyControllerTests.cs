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
using LBHVerificationHubAPI.Infrastructure.V1.API;

namespace LBHVerificationHubAPITest.Test.Controllers.V1
{
    public class PPVerifyControllerTests
    {
        private PPVerifyController _classUnderTest;
        private Mock<IVerifyUseCase> _mock;

        public PPVerifyControllerTests()
        {
            _mock = new Mock<IVerifyUseCase>();
            _classUnderTest = new PPVerifyController(_mock.Object);
        }

        [Fact]
        public async Task GivenValidRequest_WhenCallingVerify_ThenShouldReturn200()
        {
            _mock.Setup(s => s.ExecuteAsync(It.IsAny<ParkingPermitVerificationRequest>(), CancellationToken.None))
                .ReturnsAsync(new ParkingPermitVerificationResponse
                {
                });
            var request = new ParkingPermitVerificationRequest
            {

            };

            var response = await _classUnderTest.Verify(request).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
            var objectResult = response as ObjectResult;
            objectResult.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GivenValidRequest_WhenCallingVerify_ThenShouldReturnAPIResponse()
        {
            //arrange
            _mock.Setup(s => s.ExecuteAsync(It.IsAny<ParkingPermitVerificationRequest>(), CancellationToken.None))
                .ReturnsAsync(new ParkingPermitVerificationResponse
                {
                    
                });

            var request = new ParkingPermitVerificationRequest
            {
            };
            //act
            var response = await _classUnderTest.Verify(request).ConfigureAwait(false);
            //assert
            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
            var objectResult = response as ObjectResult;
            var apiResponse = objectResult?.Value as APIResponse<ParkingPermitVerificationResponse>;
            apiResponse.Should().NotBeNull();
        }

    }
}
