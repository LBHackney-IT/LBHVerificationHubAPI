using System;
using System.Threading;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.Infrastructure.V1.UseCase
{
    public interface IRawUseCaseAsync<TRequest, TResponse> where TRequest : IRequest
    {
        Task<Tuple<ParkingPermitVerificationResponse, string>> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
