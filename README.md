# Talkative
## Telegram bot api handler in .NET Standard.

The motivation: All started when i have a task, an proxy api to do, who receives an input and deliveries to Slack and Telegram, but it doesn't have any Api, Client or something for .NET.

The main class, the heart of program is the "TelegramBotClient" class, where you just need to pass your bot token, and use the respective methods, look:

```csharp
public class MyBot {
    bot = new TelegramBotClient("yourToken");

    //get bot information.
    bot.getMe()

    //get updates(messages received).
    bot.getUpdates()

    //send a message.
    bot.sendMessage(chatId, messageContent)

    //forward a message.
    bot.forwardMessage(destinationChatId, fromChatId, messageId)
}
```

Our goal is implement all methods supported by _Telegram.Inc Bot Rest Api_, so your cooperation is important.

Thanks :) 
