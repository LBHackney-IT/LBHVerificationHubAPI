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
        public VerdictDbContext() : base(GetClient())
        {
            // TODO: Do some checking to make sure DB is OK and if not, set it up?.
        }

        private static AmazonDynamoDBClient GetClient()
        {
            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID")
                            ?? throw new Exception("No AWS_ACCESS_KEY_ID found in Environment.");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY")
                            ?? throw new Exception("No AWS_SECRET_ACCESS_KEY found in Environment.");
            var regionName = Environment.GetEnvironmentVariable("AWS_REGION")
                            ?? throw new Exception("No AWS_REGION found in Environment.");
            
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var region = RegionEndpoint.GetBySystemName(regionName);
            
            return new AmazonDynamoDBClient(credentials, region);
        }
    }
}
