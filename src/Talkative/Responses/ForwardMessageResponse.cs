using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative.Responses
{
    public class ForwardMessageResponse : SendMessageResponse
    {
        public TelegramBaseProperties ForwardFrom { get; set; }
        public int ForwardDate { get; set; }
    }
}
