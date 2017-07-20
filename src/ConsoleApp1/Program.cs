using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talkative;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            var bot = new TelegramBotClient("376943020:AAGRPq8w32J403Ek6WlkRpYPlcMP_nxFdAI");

           var updates = bot.getMe().Result;
        }
    }
}
