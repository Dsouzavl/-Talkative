namespace Talkative.Models.Request
{
    public abstract class ForwardMessageRequest : TelegramMessage
    {
        public int FromChatId { get; set; }
        public int MessageId { get; set; }
    }
}