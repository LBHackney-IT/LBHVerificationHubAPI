using System;
using Amazon;
using Amazon.CloudHSM.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;

namespace LBHVerificationHubAPI.Infrastructure.V1.Context
{
    public class VerdictDbContext : DynamoDBContext, IVerdictDbContext
    {
        public VerdictDbContext() : base(new AmazonDynamoDBClient(RegionEndpoint.GetBySystemName("eu-west-2")))
        {
        }
    }
}
