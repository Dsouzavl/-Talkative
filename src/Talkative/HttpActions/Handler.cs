using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Talkative.HttpActions
{
    internal abstract class Handler<Object>
    {        
        protected abstract Task<HttpResponseMessage> Request(HttpMethod method, HttpContent content=null);
        
        public async Task<object> DeserializeObject(object objectToDeserialize, HttpMethod method, HttpContent content=null){
             var response = await Request(method, content);
             return JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
        }
    }
}
