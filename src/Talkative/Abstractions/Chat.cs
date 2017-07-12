using System;

namespace Talkative.Abstractions{
    internal class Chat : ITelegramObject { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string UserName { get; set; }
        public string Type { get; set; }
    }
}