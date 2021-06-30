using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace VUHL.DaoTestTools
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

        public List<HttpRequestMessage> GetRequestMessages()
        {
            return SpyHttpClient.GetRequestMessages();
        }

        public List<HttpResponseMessage> GetResponseMessages()
        {
            return SpyHttpClient.GetResponseMessages();
        }
    }
}
