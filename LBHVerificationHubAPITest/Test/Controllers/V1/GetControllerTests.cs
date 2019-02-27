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
    public class GetControllerTests
    {
        private GetController _classUnderTest;
        private Mock<IGetUseCase> _mock;

        public GetControllerTests()
        {
            _mock = new Mock<IGetUseCase>();
            _classUnderTest = new GetController(_mock.Object);
        }

        [Fact]
        public async Task GivenValidRequest_WhenCallingGet_ThenShouldReturn200()
        {
            _mock.Setup(s => s.ExecuteAsync(It.IsAny<GetRequest>(), CancellationToken.None))
                .ReturnsAsync(new SearchResponse
                {
                    lbhObjects = new List<LBHObject>
                    {

                    }
                });
            var id = "123";

            var response = await _classUnderTest.Get(id).ConfigureAwait(false);

            response.Should().NotBeNull();
            response.Should().BeOfType<ObjectResult>();
            var objectResult = response as ObjectResult;
            objectResult.StatusCode.Should().Be(200);

        }

    }
}
