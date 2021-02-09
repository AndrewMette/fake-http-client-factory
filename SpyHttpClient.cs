using System.Collections.Generic;
using System.Net.Http;

namespace TableFlipTestHelpers
{
    public class SpyHttpClient : HttpClient
    {
        private SpyMessageHandler SpyMessageHandler { get; }
        public SpyHttpClient(SpyMessageHandler spyMessageHandler) : base(spyMessageHandler)
        {
            SpyMessageHandler = spyMessageHandler;
        }

        public List<HttpRequestMessage> GetRequestMessages()
        {
            return SpyMessageHandler.HttpRequestMessages;
        }

        public List<HttpResponseMessage> GetResponseMessages()
        {
            return SpyMessageHandler.HttpResponseMessages;
        }
    }
}