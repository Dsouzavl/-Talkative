using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Talkative.HttpActions
{
    internal abstract class Handler<T>
    {        
        protected abstract Task<HttpResponseMessage> Requester(HttpMethod method, HttpContent content=null);
        
        protected async Task<T> HttpAction(HttpMethod method, HttpContent content=null){
             var response = await Requester(method, content);
             return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
