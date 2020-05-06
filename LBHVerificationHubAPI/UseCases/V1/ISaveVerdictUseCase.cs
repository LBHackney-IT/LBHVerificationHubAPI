using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.UseCases.V1
{
    public interface ISaveVerdictUseCase
    {
        Task<Guid> ExecuteAsync(ClearCoreResponse clearCoreResponse,
            ParkingPermitVerificationRequest request, List<string> lateMatchAudits);
    }
}