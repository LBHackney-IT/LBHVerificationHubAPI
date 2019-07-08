using ClearCoreService;
using LBHVerificationHubAPI.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.Infrastructure.V1.Services
{
    public static class ConfigureServices
    {
        public static void ConfigureClearCore(this IServiceCollection services, string clearCoreUrl, string username, string password)
        {
            services.AddTransient<UseCases.V1.Objects.IVerifyUseCase, UseCases.V1.Objects.VerifyUseCase>();
            services.AddTransient<Gateways.V1.IClearCoreGateway>(s => new Gateways.V1.ClearCoreGateway(s.GetService<IClearCoreSoap>(), clearCoreUrl));
            services.AddSingleton<IWCFClientFactory, WCFClientFactory>();

            //services.AddTransient<IClearCoreSoapChannel>(s =>
            //{
            //    var clientFactory = s.GetService<IWCFClientFactory>();
            //    //var client = clientFactory.CreateClient<IClearCoreSoapChannel>(clearCoreUrl);
            //    var client = clientFactory. CreateClient<IClearCoreSoapChannel>(clearCoreUrl);
            //    if (client.State != CommunicationState.Opened)
            //        client.Open();
            //    return client;
            //});

            services.AddTransient<IClearCoreSoap>(s =>
            {
                return new ClearCoreSoapClient(clearCoreUrl, new System.TimeSpan(0, 0, 30), username, password);
            });

        }
    }
}
