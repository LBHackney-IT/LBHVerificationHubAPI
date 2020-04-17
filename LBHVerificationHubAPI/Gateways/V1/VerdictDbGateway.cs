using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.Infrastructure.V1.Context;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public class VerdictDbGateway : IVerdictDbGateway
    {
        private readonly IVerdictDbContext _verdictDbContext;

        public VerdictDbGateway(IVerdictDbContext verdictDbContext)
        {
            _verdictDbContext = verdictDbContext;
        }

        public void AppendVerdict(Verdict verdict)
        {
            _verdictDbContext.Save(verdict);
        }
    }
}