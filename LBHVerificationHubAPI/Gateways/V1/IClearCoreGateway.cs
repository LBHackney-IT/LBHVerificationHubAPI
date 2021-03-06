﻿using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.Gateways.V1
{
    public interface IClearCoreGateway
    {
        Task<ClearCoreResponse> Verify(ParkingPermitVerificationRequest request, CancellationToken cancellationToken);
        Task<List<string>> GetLateMatchAudits(string responseMatchAudit);
    }
}
