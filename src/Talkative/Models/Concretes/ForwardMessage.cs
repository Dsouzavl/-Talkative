using System;
using Talkative.Models.Abstractions;

namespace Talkative.Models.Concretes{
    public class ForwardMessage : TelegramMessage{
        public TelegramEntity ForwardFrom { get; set; }
        public int ForwardDate { get; set; }
    }
}