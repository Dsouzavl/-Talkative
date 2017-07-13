using System;
using Talkative.Models.Abstractions;

namespace Talkative.Models.Concretes{
    public class Chat : TelegramEntity{ 
        public string Type { get; set; }
    }
}