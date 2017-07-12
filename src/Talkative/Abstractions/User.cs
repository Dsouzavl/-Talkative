using System;

namespace Talkative.Abstractions{
    internal class User : ITelegramObject{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set;}
    }
}