using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Talkative.Requests;
using Talkative.Responses;

namespace Talkative
{
    public class Bot
    {
        readonly HttpClient _client;
    
        readonly string _baseUri;

        readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public Bot(string token){
            _client = new HttpClient();
            
            if(ValidateToken(token)){
               _baseUri = $"https://api.telegram.org/bot{token}/";
            } else{
                throw new ArgumentException("Invalid token received");
            }

            _client.DefaultRequestHeaders.Clear();
        }

        public TelegramBaseProperties GetMe()
        {
            var requestRet = _client.GetAsync(_baseUri + "getMe").Result;
            var requestCont = requestRet.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TelegramBaseResponse<TelegramBaseProperties>>(requestCont, _settings).Result;
        }

        public GetUpdateResponse[] GetUpdates()
        {
            var requestRet = _client.GetAsync(_baseUri + "getUpdates").Result;
            var requestCont = requestRet.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TelegramBaseResponseMultiple<GetUpdateResponse>>(requestCont, _settings).Result;
        }

        public SendMessageResponse SendMessage(int chatId, string text)
        {
            var requestRet =  _client.PostAsync(_baseUri + "sendMessage", BuildContent(new SendMessageRequest(chatId,text))).Result;
            var requestCont = requestRet.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TelegramBaseResponse<SendMessageResponse>>(requestCont, _settings).Result;
        }

        public ForwardMessageResponse ForwardMessage(int destinyChatId, int originChatId, int messageId)
        {
            var requestRet = _client.PostAsync(_baseUri + "forwardMessage",
                BuildContent(new ForwardMessageRequest(destinyChatId, originChatId, messageId))).Result;
            var requestCont = requestRet.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TelegramBaseResponse<ForwardMessageResponse>>(requestCont, _settings).Result;
        }

        private bool ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token) || token.Contains(" "))
                return false;

            var sptToken = token.Split(':').First();

            return (sptToken.All(c => char.IsDigit(c) && sptToken.Length > 3));
        }

        private HttpContent BuildContent(object content)
        {
           return new StringContent(JsonConvert.SerializeObject(content, _settings), Encoding.UTF8,"application/json");;
        }
    }
}
