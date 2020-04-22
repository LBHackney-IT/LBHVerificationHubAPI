using System;
using System.ComponentModel.DataAnnotations;

namespace LBHVerificationHubAPI.Boundary.V1
{
    public class VerdictRequest : AbstractRequest
    {
        public Guid Guid { get; set; }
    }
}
