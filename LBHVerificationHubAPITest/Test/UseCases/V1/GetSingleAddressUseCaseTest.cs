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

namespace LBHVerificationHubAPITest
{
    public class GetSingleUseCaseTest
    {
        private readonly IGetUseCase _classUnderTest;
        private readonly Mock<IGateway> _fakeGateway;


        public GetSingleUseCaseTest()
        {
            _fakeGateway = new Mock<IGateway>();

            _classUnderTest = new GetUseCase(_fakeGateway.Object);
        }

        [Fact]
        public async Task GivenValidInput__WhenExecuteAsync_GatewayReceivesCorrectInputLength()
        {

            var id = "ABCDEFGHIJKLMN";
            _fakeGateway.Setup(s => s.GetSingleAsync(It.Is<GetRequest>(i => i.ID.Equals("ABCDEFGHIJKLMN")), CancellationToken.None)).ReturnsAsync(new LBHObject());

            var request = new GetRequest
            {
                ID = id
            };

            await _classUnderTest.ExecuteAsync(request, CancellationToken.None);

            _fakeGateway.Verify(v => v.GetSingleAsync(It.Is<GetRequest>(i => i.ID.Equals("ABCDEFGHIJKLMN")), CancellationToken.None));
        }



        [Fact]
        public async Task GivenValidInput_WhenGatewayRespondsWithNull_ThenResponseShouldBeNull()
        {
            //arrange
            var id = "ABCDEFGHIJKLMN";

            _fakeGateway.Setup(s => s.GetSingleAsync(It.Is<GetRequest>(i => i.ID.Equals("ABCDEFGHIJKLMN")), CancellationToken.None))
                .ReturnsAsync(null as LBHObject);

            var request = new GetRequest
            {
                ID = id
            };
            //act
            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None);
            //assert
            response.lbhObjects.Should().BeNull();
        }

        [Fact]
        public async Task GivenValidID_WhenExecuteAsync_ThenShouldBeReturned()
        {
            var lbhObject = new LBHObject
            {
                ID = "ABCDEFGHIJKLMN"

            };

            var id = "ABCDEFGHIJKLMN";
            var request = new GetRequest
            {
                ID = id
            };
            _fakeGateway.Setup(s => s.GetSingleAsync(It.Is<GetRequest>(i => i.ID.Equals("ABCDEFGHIJKLMN")), CancellationToken.None))
                .ReturnsAsync(lbhObject);

            var response = await _classUnderTest.ExecuteAsync(request, CancellationToken.None);

            response.Should().NotBeNull();

            var x = (LBHObject)response.lbhObjects[0];
            x.ID.Should().BeEquivalentTo(lbhObject.ID);
            x.ID.Should().NotBeNullOrEmpty();

        }
    }
}
