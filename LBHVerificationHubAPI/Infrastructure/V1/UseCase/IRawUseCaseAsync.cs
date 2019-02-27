using System.Threading;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Infrastructure.V1.API;

namespace LBHVerificationHubAPI.Infrastructure.V1.UseCase
{
    public interface IRawUseCaseAsync<TRequest, TResponse> where TRequest : IRequest
    {
        Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
