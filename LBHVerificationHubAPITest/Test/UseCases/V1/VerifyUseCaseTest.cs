using System;
using Xunit;
using LBHVerificationHubAPI.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;
using FluentAssertions;
using LBHVerificationHubAPI.Gateways.V1;
using System.Threading.Tasks;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using System.Threading;
using LBHVerificationHubAPI.Infrastructure.V1.Exceptions;
using LBHVerificationHubAPI.UseCases.V1.Objects;

namespace LBHVerificationHubAPITest
{
    public class VerifyUseCaseTest
    {
        private readonly IVerifyUseCase _classUnderTest;
        private readonly Mock<IGateway> _fakeGateway;


    }
       
}
