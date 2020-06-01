using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.Infrastructure.V1.Context;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public class VerdictDbGateway : IVerdictDbGateway
    {
        private readonly IVerdictDbContext _verdictDbContext;

        private readonly DynamoDBOperationConfig _dbConfig = new DynamoDBOperationConfig
        {
            OverrideTableName =
                $"verificationhub-logging-{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower()}"
        };

        public VerdictDbGateway(IVerdictDbContext verdictDbContext) =>
            _verdictDbContext = verdictDbContext;

        public async Task AppendVerdict(Verdict verdict) =>
            await _verdictDbContext.SaveAsync(verdict, _dbConfig);

        public async Task<Verdict> FetchVerdict(Guid verdictGuid) =>
            await _verdictDbContext.LoadAsync<Verdict>(verdictGuid, _dbConfig);
    }
}