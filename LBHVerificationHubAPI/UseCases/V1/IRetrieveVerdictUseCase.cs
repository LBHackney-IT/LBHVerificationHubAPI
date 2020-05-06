using System.Threading.Tasks;
using LBHVerificationHubAPI.Boundary.V1;

namespace LBHVerificationHubAPI.UseCases.V1
{
    public interface IRetrieveVerdictUseCase
    {
        Task<VerdictResponse> ExecuteAsync(VerdictRequest request);
    }
}
