using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LBHVerificationHubAPI.UseCases.V1.Objects;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Extensions.Controller;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System.ComponentModel.DataAnnotations;

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

        public PPVerifyController(IVerifyUseCase VerifyUseCase)
        {
            _verifyUseCase = VerifyUseCase;
        }

        /// <summary>
        /// Determines a successful verification for a provided Request 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponse<ParkingPermitVerificationCreateResponse>), 200)]
        public async Task<IActionResult> Verify([FromBody][Required]ParkingPermitVerificationCreateRequest request)
        {            
            var response = await _verifyUseCase.ExecuteAsync(request, HttpContext.GetCancellationToken()).ConfigureAwait(false);

            return HandleResponse(response);
        }

    }
}