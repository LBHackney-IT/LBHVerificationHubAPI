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
        private readonly Mock<IGateway> _fakeGateway;

        public VerifyUseCaseTest()
        {
            _fakeGateway = new Mock<IGateway>();

            _classUnderTest = new VerifyUseCase(_fakeGateway.Object);
        }

        //[Fact]
        //public async Task GivenValidedInput__WhenExecuteAsync_GatewayReceivesCorrectInput()
        //{
        //    //arrange
        //    var tenancyAgreementRef = "Test";
        //    _fakeGateway.Setup(s => s.veri(It.Is<ParkingPermitVerificationRequest>(i => i.TenancyRef.Equals("Test")), CancellationToken.None))
        //        .ReturnsAsync(new PagedResults<TenancyListItem>());

        //    var request = new ParkingPermitVerificationRequest
        //    {
                
        //    };
        //    //act
        //    await _classUnderTest.ExecuteAsync(request, CancellationToken.None);
        //    //assert
        //    _fakeGateway.Verify(v => v.SearchTenanciesAsync(It.Is<ParkingPermitVerificationRequest>(i => i.TenancyRef.Equals("Test")), CancellationToken.None));
        //}


    }       
}
