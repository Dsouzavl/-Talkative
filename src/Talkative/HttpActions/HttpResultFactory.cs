using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Talkative.HttpActions
{
    internal class HttpResultFactory
    {
        public HttpClient Client { get; set; }
        public string Url { get; set; }
        public HttpResultFactory(HttpClient httpc, string endpoint)
        {
           if(Client == null || string.IsNullOrWhiteSpace(Url)){
                throw new ArgumentNullException("Missing arguments to create response");
           }

           Client = httpc;
           Url = endpoint;
        }

        public async Task<HttpResponseMessage> Request(HttpMethod method, HttpContent content = null)
        {
            var httpm = method.Method;
            Task<HttpResponseMessage> request;
            HttpResponseMessage result;

            if (httpm == HttpMethod.Get.Method)
            {
                 request = Client.GetAsync(Url);
                 result = await request;

                 return result;
            } 

            else if(httpm == HttpMethod.Post.Method){
                request = Client.PostAsync(Url,content);
                result = await request;

                return result;
            }

            else if(httpm == HttpMethod.Delete.Method){
                request = Client.DeleteAsync(Url);
                result = await request;

                return result;
            }

            else if(httpm == HttpMethod.Put.Method){
                request = Client.PutAsync(Url,content);
                result = await request;

                return result;
            }
            else{
                throw new InvalidOperationException("Invalid http method for this operation.");
            }
        }
    }
}

