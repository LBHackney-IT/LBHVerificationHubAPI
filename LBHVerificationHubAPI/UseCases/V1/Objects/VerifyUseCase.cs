using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.Gateways.V1;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using System.Threading;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.Factories;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using LBHVerificationHubAPI.Infrastructure.V1.Exceptions;
using LBHVerificationHubAPI.Infrastructure.V1.UseCase;

namespace LBHVerificationHubAPI.UseCases.V1.Objects
{
    public class VerifyUseCase : IVerifyUseCase
    {
        private readonly IClearCoreGateway _clearCoreGateway;

        public VerifyUseCase(IClearCoreGateway clearCoreGateway)
            => _clearCoreGateway = clearCoreGateway;

        public async Task<ClearCoreResponse> ExecuteAsync(
            ParkingPermitVerificationRequest request,
            CancellationToken cancellationToken
        )
        {
            //validate
            if (request == null)
                throw new BadRequestException();

            var validationResponse = request.Validate(request);
            if (!validationResponse.IsValid)
                throw new BadRequestException(validationResponse);

            return await _clearCoreGateway.Verify(request, cancellationToken);
        }
    }
}