using System.Threading.Tasks;
using LBHVerificationHubAPI.Boundary.V1;
using LBHVerificationHubAPI.Gateways.V1;

namespace LBHVerificationHubAPI.UseCases.V1
{
    public class RetrieveVerdictUseCase : IRetrieveVerdictUseCase
    {
        private readonly IVerdictDbGateway _verdictDbGateway;

        public RetrieveVerdictUseCase(IVerdictDbGateway verdictDbGateway)
        {
            _verdictDbGateway = verdictDbGateway;
        }

        public async Task<VerdictResponse> ExecuteAsync(VerdictRequest request)
        {
            return new VerdictResponse
            {
                Verdict = await _verdictDbGateway.FetchVerdict(request.Guid)
            };
        }
    }
}
