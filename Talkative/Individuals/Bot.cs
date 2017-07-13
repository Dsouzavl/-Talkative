using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Talkative.Individuals
{
    public class Bot
    {
        private string _baseUrl;
        public string Token { get; set; }

        private HttpClient _client;

        public Bot(string token, HttpClient client)
        {
            this._client = client;
            this.Token = token;
            this._baseUrl = $"https://api.telegram.org/bot{this.Token}/";
        }

        public object GetBotInfo(){

        }
    }
}
