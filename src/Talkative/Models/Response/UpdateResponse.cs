using System;
using System.Collections.Generic;
using System.Text;

namespace Talkative.Models.Response {
    public class UpdateResponse {
        public bool Ok { get; set; }
        public List<BotUpdate> Result { get; set; }
    }

}
