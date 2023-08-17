using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TgJourneyBot.Core;

var receiverOptions = new ReceiverOptions()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

// YOUR_TOKEN
string TOKEN = "6412953598:AAGSAsZS1-S1NfhCeOLF2wKXvgJNnyjgNY4";

var botClient = new TelegramBotClient(TOKEN);
using var cts = new CancellationTokenSource();

var telegramBotHelper = new TelegramBotHelper(botClient);

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

Console.WriteLine($"Начинаем работу с - [ {await botClient.GetMeAsync()} ]");
Console.ReadLine();

cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    try
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                await telegramBotHelper.SendMessage(update, cancellationToken);
                break;
            case UpdateType.CallbackQuery:
                await telegramBotHelper.CallbackMessage(update, cancellationToken);
                break;
        };
    }
    catch (Exception ex)
    {
        await Console.Out.WriteLineAsync("Ошибка - " + ex.Message);
    }

}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException => $"Telegram API Error Code - [ {apiRequestException.ErrorCode} ] && Telegram API Error Message - [ {apiRequestException.Message} ]",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}