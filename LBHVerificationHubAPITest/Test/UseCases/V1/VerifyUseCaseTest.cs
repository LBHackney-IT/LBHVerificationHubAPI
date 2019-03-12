using System;
using Xunit;
using LBHVerificationHubAPI.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;
using FluentAssertions;
using LBHVerificationHubAPI.Gateways.V1;
using System.Threading.Tasks;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System.Threading;
using LBHVerificationHubAPI.Infrastructure.V1.Exceptions;
using LBHVerificationHubAPI.UseCases.V1.Objects;

namespace LBHVerificationHubAPITest.Test.UseCases.V1
{
    public class VerifyUseCaseTest
    {
        private readonly IVerifyUseCase _classUnderTest;
        private readonly Mock<IClearCoreGateway> _fakeGateway;

        public VerifyUseCaseTest()
        {
            _fakeGateway = new Mock<IClearCoreGateway>();

            _classUnderTest = new VerifyUseCase(_fakeGateway.Object);
        }

        [Fact]
        public async Task GivenNullInput_WhenExecuteAsync_ThenShouldThrowBadRequestException()
        {
            ParkingPermitVerificationRequest request = null;
            await Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(request, CancellationToken.None));
        }

        [Fact]
        public async Task Given_InvalidInput_ThenShouldThrowBadRequestException()
        {
            //arrange
            var request = new ParkingPermitVerificationRequest();
            await Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(request, CancellationToken.None));
        }

        [Fact]
        public async Task Given_No_Forename_ThenShouldThrowBadRequestException()
        {
            //arrange
            var request = new ParkingPermitVerificationRequest() { ForeName="", Surname="surname", UPRN="uprn" };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(request, CancellationToken.None));
        }

        [Fact]
        public async Task Given_No_Surname_ThenShouldThrowBadRequestException()
        {
            //arrange
            var request = new ParkingPermitVerificationRequest() { ForeName = "forename", Surname = "", UPRN = "uprn" };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(request, CancellationToken.None));
        }

        [Fact]
        public async Task Given_No_UPRN_ThenShouldThrowBadRequestException()
        {
            //arrange
            var request = new ParkingPermitVerificationRequest() { ForeName = "forename", Surname = "surname", UPRN = "" };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _classUnderTest.ExecuteAsync(request, CancellationToken.None));
        }
    }       
}
