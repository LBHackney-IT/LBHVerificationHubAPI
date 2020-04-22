using LBHVerificationHubAPI.Infrastructure.V1.UseCase;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Objects
{
    public interface IVerifyUseCase
    {
        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>List<string> containing the match audits from ClearCore.</returns>
        Task<ClearCoreResponse> ExecuteAsync(ParkingPermitVerificationRequest request,
            CancellationToken cancellationToken);
    }
}