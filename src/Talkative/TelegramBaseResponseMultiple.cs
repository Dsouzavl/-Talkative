using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Talkative
{
    public class TelegramBaseResponseMultiple<T>
    {
        public bool Ok { get; set; }

        public T[] Result { get; set; }
    }
}
