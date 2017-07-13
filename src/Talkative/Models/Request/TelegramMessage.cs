using Newtonsoft.Json;

namespace Talkative.Models.Request{
    public abstract class TelegramMessage{
        public int ChatId { get; set; }
        [JsonProperty("text")]
        public string Message { get; set; }
    }
}