using System.ServiceModel;

namespace LBHVerificationHubAPI.Factories
{
    /// <summary>
    /// Simple Factory for WCF clients
    /// </summary>
    public class WCFClientFactory : IWCFClientFactory
    {
        /// <summary>
        /// Creates WCF Clients without opening a connection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public T CreateClient<T>(string endpoint)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress(endpoint);
            var myChannelFactory = new ChannelFactory<T>(myBinding, myEndpoint);
            T channel = myChannelFactory.CreateChannel();
            return channel;
        }
    }
}
