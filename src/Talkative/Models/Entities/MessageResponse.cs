using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Talkative.Models.Response;

namespace Talkative.Models.Entities
{
    public class MessageResponse
    {
        public int MessageId { get; set; }
        public TelegramObject From { get; set; }
        public Chat Chat { get; set; }
        public int Date { get; set; }
        public string Text { get; set; }
    }
}
