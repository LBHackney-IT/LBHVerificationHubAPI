using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class ParkingPermitVerificationResponse 
    {  
        public bool Verified { get; set; }
        public string VerificationAuditID { get;set; }
    }
}
