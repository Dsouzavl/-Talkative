using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Talkative.HttpActions
{
    internal class HttpHandler<T> : Handler<T>
    {        
        private readonly HttpResponseFactory _factory;
        private string _url;
        public HttpHandler(HttpClient httpc, string url){
            _factory = new HttpResponseFactory(httpc,url);
        }

        protected override Task<HttpResponseMessage> Request(HttpMethod method, HttpContent content=null){
            return _factory.Request(method,content);
        }
        
        public async Task<T> GetObjectResponse(T typeOfDeserialization, HttpMethod method, HttpContent content=null){
            return await base.DeserializeObject(typeOfDeserialization,method,content);
        }
    }
}
