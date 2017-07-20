using Talkative.Models.Entities;

namespace Talkative.Models.Response {
    public class UpdateResponse { 
        public string UpdateId { get; set; }
        public TelegramObject From { get; set; }
        public Chat Chat { get; set; }
        public int Date { get; set; }
        public string Text { get; set; }
    }
}