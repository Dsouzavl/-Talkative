using Newtonsoft.Json;
using Talkative.Models.Entities;

namespace Talkative.Models.Response
{
    public class ForwardMessageResponse
    {
        public int MessageId { get; set; }
        public TelegramObject From { get; set; }
        public Chat Chat { get; set; }
        public TelegramObject  ForwardFrom{ get; set; }
        public int ForwardDate { get; set; }
        public string Text { get; set; }
    }
}