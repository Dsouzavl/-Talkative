namespace Talkative.Responses {
    public class SendMessageResponse {
        public int MessageId { get; set; }
        public TelegramBaseProperties From { get; set; }
        public Chat Chat { get; set; }
        public int Date { get; set; }
        public string Text { get; set; }
    }
}