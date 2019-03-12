using LBHVerificationHubAPITest.Helpers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LBHVerificationHubAPITest.Helpers
{
    public class Fake
    {
        public ClearCoreResponse GetFakeVerifiedResponse()
        {
            return new ClearCoreResponse { Verified = true, VerificationAuditID = new Guid().ToString() };
        }

        public ClearCoreResponse GetFakeUnVerifiedResponse()
        {
            return new ClearCoreResponse { Verified = false, VerificationAuditID = new Guid().ToString() };
        }
    }
}
