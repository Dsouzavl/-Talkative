using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative.Responses
{
    public class GetUpdateResponse 
    {
        public string UpdateId { get; set; }
        public SendMessageResponse Message { get; set; }
    }
}
