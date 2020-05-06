using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Gateways.V1;

namespace LBHVerificationHubAPI.UseCases.V1
{
    public class GetLateMatchAuditsUseCase : IGetLateMatchAuditsUseCase
    {
        private readonly IClearCoreGateway _clearCoreGateway;

        public GetLateMatchAuditsUseCase(IClearCoreGateway clearCoreGateway)
        {
            _clearCoreGateway = clearCoreGateway;
        }

        public async Task<List<string>> ExecuteAsync(List<string> matchAudits)
        {
            return await _clearCoreGateway.GetLateMatchAudits(matchAudits.FirstOrDefault());
        }
    }
}