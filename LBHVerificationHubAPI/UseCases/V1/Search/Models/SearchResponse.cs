using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class ParkingPermitVerificationCreateResponse 
    {
        [JsonProperty("modelname")]
        public List<LBHObject> lbhObjects { get; set; }
      
    }
}
