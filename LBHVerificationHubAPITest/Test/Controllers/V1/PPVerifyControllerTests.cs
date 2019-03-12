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
        public async Task GivenValidRequest_WhenCallingGet_ThenShouldReturn200()
        {
            _mock.Setup(s => s.ExecuteAsync(It.IsAny<ParkingPermitVerificationCreateRequest>(), CancellationToken.None))
                .ReturnsAsync(new ParkingPermitVerificationCreateResponse
                {
                });
            var request = new ParkingPermitVerificationCreateRequest
            {

            };

            var response = await _classUnderTest.Verify(request).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
            var objectResult = response as ObjectResult;
            objectResult.StatusCode.Should().Be(200);

        }

    }
}
