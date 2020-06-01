using System;
using System.Collections.Generic;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.Factories
{
    public static class VerdictFactory
    {
        public static Verdict FromParkingPermitVerificationResponse(
            ClearCoreResponse response,
            ParkingPermitVerificationRequest request,
            List<string> lateMatchAudits
        )
        {
            if (!Guid.TryParse(response.VerificationAuditID, out var checkedGuid))
                checkedGuid = Guid.NewGuid();

            return new Verdict
            {
                GeneratedAt = DateTime.Now,
                Uprn = request.UPRN,
                Verified = response.verified,
                VerdictId = checkedGuid,
                Request = request,
                LateMatchAudits = lateMatchAudits
            };
        }
    }
}