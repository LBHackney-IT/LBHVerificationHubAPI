using System;

namespace LBHVerificationHubAPI.UseCases.V1
{
    public class TestOpsErrorException : Exception
    {
        public TestOpsErrorException() : base("This is a test exception to test our integrations"){}
    }
}