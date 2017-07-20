using System;
using System.Net.Http;
using System.Threading.Tasks;
using Talkative.Models.Request;

namespace Talkative.Common
{
    internal class HttpRequestHandler<T> : IDisposable
    {

        private ApiResponse<T> _responseHandler;
        private readonly HttpRequestMessage _request;
        private readonly HttpClient _client;
        private HttpResponseMessage _response;

        public HttpRequestHandler(HttpRequestMessage request)
        {
            _client = new HttpClient();
            _request = request;
        }
        public async Task<T> HandleHttpAction()
        {
            var response = await _client.SendAsync(_request).ConfigureAwait(false);

            _responseHandler = new ApiResponse<T>(response);

            var result = await _responseHandler.GetResponse().ConfigureAwait(false);

            return result;
        }
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}