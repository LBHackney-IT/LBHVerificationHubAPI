using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBHVerificationHubAPI.Helpers;
using LBHVerificationHubAPI.Interfaces;
using LBHVerificationHubAPI.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace LBHVerificationHubAPI
{
    public static class ServiceConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
        }
    }
}
