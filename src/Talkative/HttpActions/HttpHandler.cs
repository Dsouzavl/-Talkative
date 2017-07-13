using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Talkative.HttpActions
{
    internal class HttpHandler<T> : Handler<T>
    {        
        private readonly HttpResultFactory _factory;
        public HttpHandler(HttpClient httpc, string url){
            _factory = new HttpResultFactory(httpc,url);
        }

        protected override Task<HttpResponseMessage> Requester(HttpMethod method, HttpContent content=null){
            return _factory.Request(method,content);
        }
        
        public async Task<T> HandleHttpAction(HttpMethod method, HttpContent content=null){
            return await base.HttpAction(method,content);
        }
    }
}
