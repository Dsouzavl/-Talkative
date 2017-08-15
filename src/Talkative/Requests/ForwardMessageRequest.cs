namespace Talkative.Requests
{
    public class ForwardMessageRequest 
    {
        public int ChatId { get; set; }
        public int FromChatId { get; set; }
        public int MessageId { get; set;  }
        public ForwardMessageRequest(int destinyChatId, int originChatId, int messageId)
        {
            this.ChatId = destinyChatId;
            this.FromChatId = originChatId;
            this.MessageId = messageId;
        }
    }
}
