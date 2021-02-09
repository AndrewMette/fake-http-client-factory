using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TableFlipTestHelpers
{
    public class SpyMessageHandler : HttpClientHandler
    {
        internal List<HttpRequestMessage> HttpRequestMessages { get; }
        internal List<HttpResponseMessage> HttpResponseMessages { get; }
        public SpyMessageHandler()
        {
            HttpRequestMessages = new List<HttpRequestMessage>();
            HttpResponseMessages = new List<HttpResponseMessage>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpRequestMessages.Add(request);
            var response = await base.SendAsync(request, cancellationToken);
            HttpResponseMessages.Add(response);
            return response;

        }
    }
}