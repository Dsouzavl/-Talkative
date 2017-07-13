using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace Talkative.Builders
{
    internal class HttpRequestBuilder
    {
        private readonly HttpContent _requestBody;
        private readonly Uri _baseUri;
        private readonly HttpMethod _method;
        private readonly HttpContent _content;
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public HttpRequestBuilder(Uri uri, HttpMethod method, HttpContent content)
        {
            _baseUri = uri;
            _method = method;
            _content = content;
        }

        public HttpRequestBuilder AddResource(string resourcePath)
        {
            var finalUrl = new Uri(_baseUri, resourcePath);
            return new HttpRequestBuilder(finalUrl, _method, _content);
        }

        public HttpRequestBuilder WithMethod(HttpMethod method)
        {
            return new HttpRequestBuilder(_baseUri, method, _content);
        }

        public HttpRequestBuilder AndContent(object content)
        {
            JsonConvert.DefaultSettings = () => _serializerSettings;
            var jsonContent = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            return new HttpRequestBuilder(_baseUri,_method,stringContent);
        }

        public HttpRequestMessage Build()
        {
            var message = new HttpRequestMessage(_method,_baseUri) { Content = _content};
            
            return message;
        }
    }
}