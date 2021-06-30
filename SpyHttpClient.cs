using System.Collections.Generic;
using System.Net.Http;

namespace VUHL.DaoTestTools
{
    public class SpyHttpClient : HttpClient
    {
        private SpyMessageHandler SpyMessageHandler { get; }
        internal SpyHttpClient(SpyMessageHandler spyMessageHandler) : base(spyMessageHandler)
        {
            SpyMessageHandler = spyMessageHandler;
        }

        public SpyHttpClient() : this(new SpyMessageHandler())
        {

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