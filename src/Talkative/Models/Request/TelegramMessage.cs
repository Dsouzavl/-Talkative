using Newtonsoft.Json;

namespace Talkative.Models.Request
{
    public abstract class TelegramMessage
    {
        public int ChatId { get; set; }
        public string Text { get; set; }
    }
}