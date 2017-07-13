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

        public TelegramBotClient(string token, Uri apiUrl) : this(token)
        {
            _baseUri = new Uri(apiUrl, $"/bot{token}");
        }

        public async Task<BaseResponse> getMe()
        {
            var request = new HttpRequestBuilder(_baseUri, HttpMethod.Get, null).AddResource("/getMe")
                                                .Build();

            var response = await _client.SendAsync(request).ConfigureAwait(false);

            var result = new ApiResponse<BaseResponse>(response);

            var bot = await result.GetResponse().ConfigureAwait(false);

            return bot;
        }

        public async Task<TelegramMessage> sendMessage(int chatId, string messageContent)
        {
            var request = new HttpRequestBuilder(_baseUri, HttpMethod.Get, null).AddResource("/getMe")
                                                .Build();

            var response = await _client.SendAsync(request).ConfigureAwait(false);

            var result = new ApiResponse<BaseResponse>(response);

            var bot = await result.GetResponse().ConfigureAwait(false);

            return bot;
        }

        public async Task<ForwardMessage> forwardMessage(int destinationChatId, int fromChatId, int messageId)
        {
            var url = _baseUri + $"/forwardMessage";

            var body = new StringContent($@" chat_id:{destinationChatId},
                                             from_chat_id:{fromChatId},
                                             message_id:{messageId}
                                        ");
            var handler = new HttpHandler<ForwardMessage>(_client, url);

            var messageResult = await handler.HandleHttpAction(HttpMethod.Post, body);

            return messageResult;
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
