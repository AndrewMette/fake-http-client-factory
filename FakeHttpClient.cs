using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace TableFlipTestHelpers
{
    public class FakeHttpClient : HttpClient
    {
        private FakeMessageHandler FakeMessageHandler { get; }
        public FakeHttpClient(FakeMessageHandler fakeMessageHandler) : base(fakeMessageHandler)
        {
            FakeMessageHandler = fakeMessageHandler;
        }

        #region Queue Responses And Exceptions
        public void QueueResponse(HttpResponseMessage response) => FakeMessageHandler.Responses.Enqueue(response);

        public void QueueResponse(HttpStatusCode statusCode)
        {
            var response = new HttpResponseMessage(statusCode);
            QueueResponse(response);
        }

        public void QueueResponseWithJsonContent(HttpStatusCode statusCode, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(json)
            };
            QueueResponse(response);
        }

        public void QueueResponseWithXmlContent(HttpStatusCode statusCode, string xmlString)
        {
            try
            {
                XElement.Parse(xmlString);
            }
            catch (XmlException e)
            {
                throw new InvalidOperationException($"cannot parse xml string: {xmlString}", e);
            }

            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(xmlString)
            };
            QueueResponse(response);
        }

        public void QueueResponseWithXmlContent(HttpStatusCode statusCode, XContainer xml)
        {
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(xml.ToString())
            };
            QueueResponse(response);
        }

        public void QueueException(Exception exception) => FakeMessageHandler.Exceptions.Enqueue(exception);
        #endregion

        public IEnumerable<HttpRequestMessage> GetRequests() => FakeMessageHandler.Requests;
    }
}