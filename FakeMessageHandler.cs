using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VUHL.DaoTestTools
{
    public class FakeMessageHandler : HttpMessageHandler
    {
        // Responses to return
        internal readonly Queue<HttpResponseMessage> Responses = new Queue<HttpResponseMessage>();

        // Exceptions to throw
        internal readonly Queue<Exception> Exceptions = new Queue<Exception>();

        // Requests that were sent via the handler
        internal readonly List<HttpRequestMessage> Requests = new List<HttpRequestMessage>();

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add(request);

            if (Responses.Count == 0 && Exceptions.Count == 0)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }

            if (Exceptions.Count != 0)
            {
                var exception = Exceptions.Dequeue();
                throw exception;
            }

            var response = Responses.Dequeue();
            return Task.FromResult(response);
        }
    }
}