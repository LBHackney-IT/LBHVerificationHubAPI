using LBHVerificationHubAPI.Infrastructure.V1.UseCase;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Objects
{
    public interface IVerifyUseCase : IRawUseCaseAsync<ParkingPermitVerificationRequest, ParkingPermitVerificationCreateResponse>
    {
    }
}
