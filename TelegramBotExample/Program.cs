using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

TelegramBotClient client = new("5626535732:AAGcgfVoFAj3uegMxBOqJc08NUBUo30mz8E");

client.StartReceiving(UpdateHandler, ErrorHandler);

async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken arg3)
{
    string id = update.Message.Chat.Id.ToString();
    await botClient.SendTextMessageAsync(
            chatId: id,
            text: "Message with inline keyboard markup",
            replyMarkup: new InlineKeyboardMarkup(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithUrl(
                        "Link to Repository",
                        "https://github.com/TelegramBots/Telegram.Bot"
                    )
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData("callback_data1"),
                    InlineKeyboardButton.WithCallbackData("callback_data2", "data"),
                },
                new [] { InlineKeyboardButton.WithSwitchInlineQuery("switch_inline_query"), },
                new [] { InlineKeyboardButton.WithSwitchInlineQueryCurrentChat("switch_inline_query_current_chat"), },
            })
        );

}
#region Send message without buttons
//await botClient.SetChatMenuButtonAsync(update.Message.Chat.Id);
//if (update.Type == UpdateType.Message)
//{
//    if (update.Message.Type == MessageType.Text)
//    {
//        string text = update.Message.Text;
//        switch (text)
//        {
//            case "/start":
//                await botClient.SendTextMessageAsync(id, "" +
//            @"<b style='color:red;'>Welcome Anar Balaca</b>", ParseMode.Html);
//                break;
//            case "Anar":
//                await botClient.SendTextMessageAsync(id, "" +
//            @"<b style='color:red;'>Mən də bilmirəm</b>", ParseMode.Html);
//                break;
//            default: break;
//        }

//    }
//    else if (update.Message.Type == MessageType.Voice)
//    {
//        await botClient.SendTextMessageAsync(id, "" +
//    @"<b style='color:red;'>Sus Anar</b>", ParseMode.Html);
//    }
//} 
#endregion
async Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
{
    Console.WriteLine(arg2.Message);
}

Console.Read();
