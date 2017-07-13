using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Talkative.HttpActions
{
    internal abstract class Handler<T>
    {        
        protected abstract Task<HttpResponseMessage> Request(HttpMethod method, HttpContent content=null);
        
        public async Task<T> DeserializeObject(T objectToDeserialize, HttpMethod method, HttpContent content=null){
             var response = await Request(method, content);
             return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
