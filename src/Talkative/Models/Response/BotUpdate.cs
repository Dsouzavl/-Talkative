using Talkative.Models.Entities;

namespace Talkative.Models.Response {
    public class BotUpdate {
        public string UpdateId { get; set; }
        
        public MessageResponse Message { get; set; }
    }
}