using System;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Domain;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public interface IVerdictDbGateway
    {
        Task AppendVerdict(Verdict verdict);
        Task<Verdict> FetchVerdict(Guid verdictGuid);
    }
}
