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
        public static void ConfigureSearch(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<UseCases.V1.Objects.IGetUseCase, UseCases.V1.Objects.GetUseCase>();
            services.AddTransient<Gateways.V1.IGateway>(s => new Gateways.V1.Gateway(connectionString));
        }
    }
}
