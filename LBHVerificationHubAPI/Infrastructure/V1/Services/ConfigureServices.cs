using ClearCoreService;
using LBHVerificationHubAPI.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
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
                ClearCoreSoapClient c = new ClearCoreSoapClient(clearCoreUrl, new System.TimeSpan(0, 0, 30), username, password);
                c.ClientCredentials.UserName.UserName = username;
                c.ClientCredentials.UserName.Password = password;
                c.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                //c.ClientCredentials.ClientCertificate.Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(@"C:\Users\mkeyworth\Source\Repos\LBHVerificationHubAPI\LBHVerificationHubAPI\VHub.pem");
                //c.ClientCredentials.ClientCertificate.Certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2("VHub.pem");
                c.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
                    new X509ServiceCertificateAuthentication()
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    };
                return c ;
            });

        }
    }
}
