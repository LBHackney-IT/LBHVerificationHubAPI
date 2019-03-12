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

        private readonly IGateway _Gateway;

        public VerifyUseCase(IGateway Gateway)
        {
            _Gateway = Gateway;
        }

        public async Task<ParkingPermitVerificationCreateResponse> ExecuteAsync(ParkingPermitVerificationRequest request, CancellationToken cancellationToken)
        {

            //validate
            if (request == null)
                throw new BadRequestException();


            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);

            var response = await _Gateway.GetSingleAsync(request, cancellationToken).ConfigureAwait(false);

            if (response == null)
                return new ParkingPermitVerificationCreateResponse();
            var useCaseResponse = new ParkingPermitVerificationCreateResponse
            {
                //lbhObjects = new List<LBHObject> { response }
            };


            return useCaseResponse;


        }
    }
}
