using System.Net.Http;

namespace TableFlipTestHelpers
{
    public class FakeHttpClientFactory : IHttpClientFactory
    {
        public FakeHttpClient FakeHttpClient { get; }

        public FakeHttpClientFactory()
        {
            var fakeMessageHandler = new FakeMessageHandler();
            FakeHttpClient = new FakeHttpClient(fakeMessageHandler);
        }

        public HttpClient CreateClient(string name = null)
        {
            return FakeHttpClient;
        }
    }
}
