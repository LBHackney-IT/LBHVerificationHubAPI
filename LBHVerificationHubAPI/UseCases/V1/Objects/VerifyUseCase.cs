using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.Gateways.V1;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using System.Threading;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using LBHVerificationHubAPI.Infrastructure.V1.Exceptions;

namespace LBHVerificationHubAPI.UseCases.V1.Objects
{
    public class VerifyUseCase : IVerifyUseCase
    {

        private readonly IClearCoreGateway _Gateway;

        public VerifyUseCase(IClearCoreGateway Gateway)
        {
            _Gateway = Gateway;
        }

        public async Task<Tuple<ParkingPermitVerificationResponse,string>> ExecuteAsync(ParkingPermitVerificationRequest request, CancellationToken cancellationToken)
        {

            //validate
            if (request == null)
                throw new BadRequestException();


            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);

            var response = await _Gateway.Verify(request, cancellationToken).ConfigureAwait(false);
            
            if (response == null)
                return new Tuple<ParkingPermitVerificationResponse, string>(new ParkingPermitVerificationResponse(), "");
            
            List<string> lateMatches = new List<string>();
            if (response.matchAudits != null)
                lateMatches = await _Gateway.GetLateMatchAudits(response.matchAudits[0]);
            else
                lateMatches.Append("NONE");

            var useCaseResponse = new ParkingPermitVerificationResponse
            {
                Verified = response.verified,
                VerificationAuditID = response.VerificationAuditID,
            };


            return new Tuple<ParkingPermitVerificationResponse, string>(useCaseResponse, lateMatches.FirstOrDefault());


        }
    }
}
