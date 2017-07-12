using System;

namespace Talkative.Abstractions{
    internal class Message{
        public int Id { get; set; }
        public User FromUser { get; set; }
        public Chat Destination { get; set; }
        public int Date { get; set;}
        public string Text { get; set; }
    }
}