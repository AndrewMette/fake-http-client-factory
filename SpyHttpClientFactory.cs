using System.Net;
using System.Net.Http;

namespace TableFlipTestHelpers
{
    public class SpyHttpClientFactory : IHttpClientFactory
    {
        public SpyHttpClient SpyHttpClient { get; }

        public SpyHttpClientFactory(NetworkCredential credentials = null)
        {
            var spyMessageHandler = new SpyMessageHandler();
            if (credentials != null)
            {
                spyMessageHandler.Credentials = credentials;
            }

            SpyHttpClient = new SpyHttpClient(spyMessageHandler);
        }

        public HttpClient CreateClient(string name)
        {
            return SpyHttpClient;
        }
    }
}
