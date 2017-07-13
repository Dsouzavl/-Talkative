using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Talkative.Individuals
{
    public class Client
    {
        private HttpClient _client;

        public Client(string baseAddress){
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);
        }

        public Client(string baseAddress, TimeSpan requestTimeOut){
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);
            _client.Timeout = requestTimeOut;
        }
    }
}