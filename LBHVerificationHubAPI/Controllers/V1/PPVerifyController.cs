using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LBHVerificationHubAPI.UseCases.V1.Objects;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Extensions.Controller;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amazon.DynamoDBv2;
using Amazon.SimpleNotificationService.Model;
using LBHVerificationHubAPI.Extensions.String;
using LBHVerificationHubAPI.Infrastructure.V1.Exceptions;
using LBHVerificationHubAPI.UseCases.V1;
using LBHVerificationHubAPI.UseCases.V1.Search;
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
        private readonly ISaveVerdictUseCase _verdictUseCase;
        private readonly IGetLateMatchAuditsUseCase _lateMatchAuditsUseCase;

        private readonly ILogger<PPVerifyController> _logger;

        public PPVerifyController(
            IVerifyUseCase verifyUseCase,
            ISaveVerdictUseCase verdictUseCase,
            IGetLateMatchAuditsUseCase lateMatchAuditsUseCase,
            ILogger<PPVerifyController> logger)
        {
            _verifyUseCase = verifyUseCase;
            _verdictUseCase = verdictUseCase;
            _lateMatchAuditsUseCase = lateMatchAuditsUseCase;

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
            var clearCoreResponse = await _verifyUseCase
                .ExecuteAsync(request, HttpContext.GetCancellationToken());

            var lateMatchAudits = new List<string>();

            if (clearCoreResponse.matchAudits != null)
                lateMatchAudits = await _lateMatchAuditsUseCase
                    .ExecuteAsync(clearCoreResponse.matchAudits);

            var verdictGuid = await _verdictUseCase
                .ExecuteAsync(clearCoreResponse, request, lateMatchAudits);

            var prettyRequestDict = string.Join("\n", request.GetQueryDict()
                .Select(m => $"  {m.Key}: {m.Value}"));
            if (clearCoreResponse.verified)
            {
                _logger.LogInformation(
                    "\n" +
                    $"Query at {DateTime.Now}:" + '\n' +
                    prettyRequestDict + "\n\n" +
                    "Audit returned:" + '\n' +
                    $"  {lateMatchAudits}" + "\n\n" +
                    "Database Verdict Guid:" + '\n' +
                    $"  {verdictGuid}" + "\n\n"
                );
            }

            return HandleResponse(
                new ParkingPermitVerificationResponse
                {
                    Verified = clearCoreResponse.verified,
                    VerificationAuditID = clearCoreResponse.VerificationAuditID.IsNotNullOrEmptyOrWhiteSpace()
                        ? clearCoreResponse.VerificationAuditID
                        : new string($"(Not Verified) Logged with Guid: {verdictGuid.ToString()}"),
                }
            );
        }
    }
}