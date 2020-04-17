using System.Collections.Generic;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.Factories
{
    public interface IVerdictFactory
    {
        Verdict FromParkingPermitVerificationResponse(ParkingPermitVerificationResponse response,
            ParkingPermitVerificationRequest request, List<string> lateMatches);
    }
}