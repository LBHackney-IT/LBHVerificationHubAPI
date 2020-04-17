using LBHVerificationHubAPI.Domain;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public interface IVerdictDbGateway
    {
        void AppendVerdict(Verdict verdict);
    }
}