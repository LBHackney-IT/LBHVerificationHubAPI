using System;
using System.Collections.Generic;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.Factories
{
    public class VerdictFactory : IVerdictFactory
    {
        public Verdict FromParkingPermitVerificationResponse(ParkingPermitVerificationResponse response,
            ParkingPermitVerificationRequest request, List<string> lateMatches)
        {
            return new Verdict
            {
                GeneratedAt = DateTime.Now,
                Uprn = request.UPRN,
                Verified = response.Verified,
                VerdictId = Guid.NewGuid(),
                Request = request,
                LateMatchAudit = lateMatches
            };
        }
    }
}