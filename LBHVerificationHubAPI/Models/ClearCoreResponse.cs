using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Interfaces;


namespace LBHVerificationHubAPI.Models
{
    //holding object until i know what clearcore will return.
    public class ClearCoreResponse
    {
        public bool verified { get; set; }
        public string VerificationAuditID { get; set; }
        public List<string> matchAudits;
    }
}