using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.Infrastructure.V1.Services
{
    public static class ConfigureServices
    {
        public static void ConfigureClearCore(this IServiceCollection services, string clearCoreUrl)
        {
            services.AddTransient<UseCases.V1.Objects.IVerifyUseCase, UseCases.V1.Objects.VerifyUseCase>();
            services.AddTransient<Gateways.V1.IClearCoreGateway>(s => new Gateways.V1.ClearCoreGateway(clearCoreUrl));
        }
    }
}
