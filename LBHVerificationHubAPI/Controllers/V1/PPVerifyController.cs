using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LBHVerificationHubAPI.UseCases.V1.Objects;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Extensions.Controller;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace LBHVerificationHubAPI.Controllers.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v1/verificationhub/parkingpermitverification/")]
    [ProducesResponseType(typeof(APIResponse<object>), 400)]
    [ProducesResponseType(typeof(APIResponse<object>), 500)]
    public class PPVerifyController : BaseController
    {
        private readonly IVerifyUseCase _verifyUseCase;
        private readonly ILogger<PPVerifyController> _logger;

        public PPVerifyController(IVerifyUseCase VerifyUseCase, ILogger<PPVerifyController> logger)
        {
            _verifyUseCase = VerifyUseCase;
            _logger = logger;
        }

        /// <summary>
        /// Determines a successful verification for a provided Request 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<ParkingPermitVerificationResponse>), 200)]
        public async Task<IActionResult> Verify([FromBody] [Required] ParkingPermitVerificationRequest request)
        {
            var (response, matchDescription) = await _verifyUseCase
                .ExecuteAsync(request, HttpContext.GetCancellationToken()).ConfigureAwait(false);

            var queryDictString = string.Join("\n", request.GetQueryDict()
                .Select(m => $"  {m.Key}: {m.Value}"));

            if (response.Verified)
            {
                _logger.LogInformation(
                    "\n" +
                    $"Query at {DateTime.Now}:" + "\n" +
                    queryDictString + "\n\n" +
                    "Audit returned:" + "\n" +
                    $"  {matchDescription}" + "\n\n"
                );
            }

            return HandleResponse(response);
        }
    }
}