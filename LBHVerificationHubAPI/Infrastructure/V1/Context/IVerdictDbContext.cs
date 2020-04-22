using Amazon.DynamoDBv2.DataModel;
using LBHVerificationHubAPI.Gateways.V1;

namespace LBHVerificationHubAPI.Infrastructure.V1.Context
{
    public interface IVerdictDbContext : IDynamoDBContext
    {
    }
}