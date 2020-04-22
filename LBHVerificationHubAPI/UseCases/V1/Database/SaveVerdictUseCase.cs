using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Factories;
using LBHVerificationHubAPI.Gateways.V1;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.UseCases.V1
{
    /// <summary>
    /// Packages the request and response into the Verdict model and writes it to the database.
    /// </summary>
    public class SaveVerdictUseCase : ISaveVerdictUseCase
    {
        private readonly IVerdictDbGateway _verdictGateway;

        public SaveVerdictUseCase(IVerdictDbGateway verdictGateway)
        {
            _verdictGateway = verdictGateway;
        }

        public async Task<Guid> ExecuteAsync(
            ClearCoreResponse clearCoreResponse,
            ParkingPermitVerificationRequest request,
            List<string> lateMatchAudits
        )
        {
            var verdict = VerdictFactory
                .FromParkingPermitVerificationResponse(clearCoreResponse, request, lateMatchAudits);

            await _verdictGateway.AppendVerdict(verdict);

            return verdict.VerdictId;
        }
    }
}