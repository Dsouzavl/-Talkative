namespace Talkative.Models.Abstractions{
    public abstract class TelegramEntity{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set;}
    }
}