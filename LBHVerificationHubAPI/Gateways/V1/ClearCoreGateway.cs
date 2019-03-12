using LBHVerificationHubAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Threading;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Helpers;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public class ClearCoreGateway : IClearCoreGateway
    {
        private readonly string _clearCoreURL;
        public ClearCoreGateway(string ClearCoreURL)
        {
            _clearCoreURL = ClearCoreURL;
        }

        /// <summary>
        /// Return an  for a given LPI_Key
        /// </summary>
        /// <param name="request"></param> 
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ClearCoreResponse> Verify(ParkingPermitVerificationRequest request, CancellationToken cancellationToken)
        {
            //call the ClearCore web service
            var result = new ClearCoreResponse() { verified=true, VerificationAuditID=new Guid().ToString() };
            return result;
        }
    }
}
