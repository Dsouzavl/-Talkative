using System;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;

namespace Talkative
{
    internal class Bot
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        private string _baseUrl { get; set; }
        private string _token { get; set; }
        private HttpClient _client { get; set;}

        public Bot(string token, string baseUrl = null){
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

        public Bot GetMe(){
            var url = _baseUrl + $"{_token}/getMe";
            using(_client){
                var request = _client.GetAsync(url);
                var result= await request;
                JsonConvert.DeserializeObject<Bot>(requestResult);
            }
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
