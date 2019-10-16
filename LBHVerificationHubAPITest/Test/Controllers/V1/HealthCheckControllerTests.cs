using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using LBHVerificationHubAPI.Controllers.V1;
using LBHVerificationHubAPI.UseCases.V1;

namespace LBHVerificationHubAPITest.Test.Controllers.V1
{
    public class HealthCheckControllerTests
    {
        private HealthCheckController _classUnderTest;


        public HealthCheckControllerTests()
        {
            _classUnderTest = new HealthCheckController();
        }

        [Fact]
        public void ReturnsResponseWithStatus()
        {
            var response = _classUnderTest.HealthCheck() as OkObjectResult;

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, 200);
            Assert.Equal(new Dictionary<string, object> {{"success", true}}, response.Value);

        }

        [Fact]
        public void ThrowErrorThrows()
        {
            Assert.Throws<TestOpsErrorException>(_classUnderTest.ThrowError);
        }
    }
}