using System;
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
            Console.WriteLine(request.Guid);

            Console.WriteLine($"Sending {request.Guid} to Use Case");
            var verdict = await _verdictDbGateway.FetchVerdict(request.Guid);
            
            return new VerdictResponse
            {
                Verdict = verdict
            };
        }
    }
}