using System.Threading;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Infrastructure.V1.UseCase.Execution;

namespace LBHVerificationHubAPI.Infrastructure.V1.UseCase
{
    public interface IUseCaseAsync<TRequest, TResponse> where TRequest : IRequest
    {
        Task<IExecuteWrapper<TResponse>> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
