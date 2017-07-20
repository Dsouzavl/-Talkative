using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using Talkative.Models.Response;
using Talkative.Builders;
using Talkative.Models.Request;
using Talkative.Models.Entities;
using Talkative.Common;
using System.Collections.Generic;

namespace Talkative
{
    public class TelegramBotClient
    {
        private Uri _baseUri;
        private readonly string _token;

        public TelegramBotClient(string token)
        {
            if (ValidateToken(token) == false)
            {
                throw new Exception("Invalid token");
            };

            _token = token;

            _baseUri = new Uri($"https://api.telegram.org/bot{token}");
        }

        public TelegramBotClient(string token, Uri apiUri) : this(token)
        {
            _baseUri = new Uri(apiUri, $"/bot{token}");
        }

        public async Task<TelegramObject> getMe() 
        {
            var builder = new HttpRequestBuilder(_baseUri, HttpMethod.Get,null);
            
            var request =  builder.AddResource("/getMe").Build();

            var handler = new HttpRequestHandler<TelegramObject>(request);

            var bot = await handler.HandleHttpAction();

            return bot;
        }

        public async Task<TelegramObject> getUpdates(){
            var builder = new HttpRequestBuilder(_baseUri, HttpMethod.Get, null);
            
            var request = builder.AddResource("getUpdates").Build();

            var handler = new HttpRequestHandler<TelegramObject>(request);

            var updates = await handler.HandleHttpAction();

            return updates;
        }

        public async Task<TelegramMessage> sendMessage(int chatId, string messageContent)
        {
            var builder = new HttpRequestBuilder(_baseUri, HttpMethod.Post,null);

            var request =  builder.AddResource("/sendMessage").AndContent(typeof(TelegramMessage)).Build();
                                
            var handler = new HttpRequestHandler<TelegramMessage>(request);

            var result = await handler.HandleHttpAction();
            
            return result;
        }

        public async Task<ForwardMessageResponse> forwardMessage(int destinationChatId, int fromChatId, int messageId)
        {
            var builder = new HttpRequestBuilder(_baseUri, HttpMethod.Post,null);

            var request =  builder.AddResource("/forwardMessage").AndContent(typeof(ForwardMessageRequest)).Build();
                                
            var handler = new HttpRequestHandler<ForwardMessageResponse>(request);

            var result = await handler.HandleHttpAction();
            
            return result;
        }

        private bool ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var tokenIdentifier = token.Split(':').First();
            return (tokenIdentifier.All(c => char.IsDigit(c) && tokenIdentifier.Length > 3));
        }
    }
}
