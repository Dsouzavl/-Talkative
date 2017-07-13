using System;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using Talkative.Abstractions;
using Talkative.HttpActions;
using Talkative.Models.Abstractions;
using Talkative.Models.Concretes;

namespace Talkative
{
    public class Bot
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        private string _baseUrl { get; set; }
        private string _token { get; set; }
        private HttpClient _client { get; set;}

        public Bot(string token, string baseUrl = null, TimeSpan ?getInfoTimeout=null){
            _client = new HttpClient();
            
            if(getInfoTimeout != null){
                _client.Timeout = (TimeSpan) getInfoTimeout;
            }

            if(ValidateToken(token) == false){
                throw new Exception("Invalid token");
            };
            
            _token = token;

            if(baseUrl != null){
                _baseUrl = baseUrl;
            };

            _baseUrl = "https://api.telegram.org/bot";
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Talkative request",".NET Standard telegram bot client");
        }

        public async Task<Bot> getMe(){    
            var url = _baseUrl + $"{_token}/getMe";

            var handler = new HttpHandler<Bot>(_client, url);

            var bot = await handler.HandleHttpAction(HttpMethod.Get);
                
            return bot;
        }

        public async Task<TelegramMessage> sendMessage(int chatId, string messageContent){
             var url = _baseUrl + $"{_token}/sendMessage";

             var body =  new StringContent($"chat_id: {chatId}, text:{messageContent}");

             var handler = new HttpHandler<TelegramMessage>(_client,url);

             var messageResult = await handler.HandleHttpAction(HttpMethod.Post,body);

             return messageResult;
        }

        public async Task<ForwardMessage> forwardMessage(int destinationChatId, int fromChatId, int messageId){
            var url = _baseUrl + $"{_token}/forwardMessage";

            var body = new StringContent($@" chat_id:{destinationChatId},
                                             from_chat_id:{fromChatId},
                                             message_id:{messageId}
                                        ");
            var handler = new HttpHandler<ForwardMessage>(_client, url);
            
            var messageResult = await handler.HandleHttpAction(HttpMethod.Post,body);

            return messageResult;
        }

        private bool ValidateToken(string token){
            var leftSide = token.Split(':');
            var numCatch = new Regex(@"\d*");
            if(token.Contains(" ") || !numCatch.Match(leftSide[0]).Success || leftSide[0].Length < 3){
                return false;
            }
            return true;
        }
    }
}
