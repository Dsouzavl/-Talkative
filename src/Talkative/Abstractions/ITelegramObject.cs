using System;

namespace Talkative.Abstractions{
    internal interface ITelegramObject{
         int Id { get; set; }
         string FirstName { get; set; }
         string UserName { get; set;}
    }
}