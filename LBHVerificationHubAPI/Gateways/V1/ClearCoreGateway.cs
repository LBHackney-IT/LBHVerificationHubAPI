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
using ClearCoreService;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public class ClearCoreGateway : IClearCoreGateway
    {
        private readonly string _clearCoreURL;
        private readonly IClearCoreSoapChannel _clearCoreSoapChannel;
        private readonly IClearCoreSoap _clearCoreSoap;

        public ClearCoreGateway(IClearCoreSoapChannel clearCoreSoapChannel , string ClearCoreURL)
        {
            _clearCoreSoapChannel = clearCoreSoapChannel;
            _clearCoreURL = ClearCoreURL;
        }

        public ClearCoreGateway(IClearCoreSoap clearCoreSoap, string ClearCoreURL)
        {
            _clearCoreSoap = clearCoreSoap;
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
            ScvQueryDef queryDefinition = QueryHelper.CreateQueryDefinition(request);

            //ScvQueryResult results = await _clearCoreSoapChannel.ScvQueryRecords2Async(queryDefinition).ConfigureAwait(false);
            ScvQueryResult results = await _clearCoreSoap.ScvQueryRecords2Async(queryDefinition).ConfigureAwait(false);
            //if (_clearCoreSoapChannel.State != System.ServiceModel.CommunicationState.Closed)
            //{
            //    _clearCoreSoapChannel.Close();
            //}

            ClearCoreResponse response = QueryHelper.CreateResponse(results);

            return response;
        }
    }
}
