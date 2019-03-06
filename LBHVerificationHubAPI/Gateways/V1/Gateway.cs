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
    public class Gateway : IGateway
    {
        private readonly string _connectionString;
        public Gateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Return an  for a given LPI_Key
        /// </summary>
        /// <param name="request"></param> 
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LBHObject> GetSingleAsync(ParkingPermitVerificationCreateRequest request, CancellationToken cancellationToken)
        {
            var result = new LBHObject();

            //TODO: Move the query in to a helper so it's in one place!
            string query = "sql query here";
            

            return result;
        }







    }
}
