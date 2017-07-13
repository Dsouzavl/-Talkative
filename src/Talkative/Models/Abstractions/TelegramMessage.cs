namespace Talkative.Models.Abstractions{
    public abstract class TelegramMessage{
        public bool Ok { get; set; }
        public int Id { get; set; }
        public TelegramEntity From { get; set; }
        public TelegramEntity Destination { get; set; }
        public int Date { get; set;}
        public string Text { get; set; }
    }
}