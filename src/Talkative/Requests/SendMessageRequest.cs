namespace Talkative.Requests{
    public class SendMessageRequest{
        public int ChatId{ get; set; }
        public string Text { get; set; }
        
        public SendMessageRequest(int chatId, string text){
            this.ChatId = chatId;
            this.Text = text;
        }
    }
}