using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Talkative.Models.Request
{
    internal class ApiResponse<T>
    {
        public readonly bool IsSuccess;
        public readonly HttpStatusCode HttpStatusCode;
        public readonly HttpResponseMessage HttpErrorResponse;
        private readonly HttpResponseMessage _response;
        private readonly JsonSerializerSettings _jsonSerializeSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver 
            { 
                NamingStrategy = new SnakeCaseNamingStrategy() 
            }
        };

        public ApiResponse(HttpResponseMessage response)
        {
            _response = response;
            IsSuccess = response.IsSuccessStatusCode;
            HttpStatusCode = response.StatusCode;

            if(!IsSuccess)
                HttpErrorResponse = response;
        }

        public async Task<T> GetResponse()
        {
            if(IsSuccess && _response.StatusCode != HttpStatusCode.NoContent)
            {
                var content = await _response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var responseMessage = await Task.FromResult(
                    JsonConvert.DeserializeObject<T>(content,_jsonSerializeSettings)).ConfigureAwait(false);

                return responseMessage;
            }

            return default(T);
        }
    }
}