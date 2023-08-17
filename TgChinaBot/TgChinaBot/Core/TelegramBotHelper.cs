using Telegram.Bot;
using Telegram.Bot.Types;
using TgJourneyBot.Core.Model;
using TgJourneyBot.Core.Service.Abstract;

namespace TgJourneyBot.Core;

public class TelegramBotHelper
{
    private ITelegramBotClient _botClient;

    private Handler _root = new DataModel().Root;
    private Dictionary<long, UserModel> _users = new();

    private const long CHAT_RESULT_ID = 6026816676; //1494671992;

    public TelegramBotHelper(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task SendMessage(Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;

        if (message.Text is not { } messageText)
            return;

        var chatId = message.Chat.Id;
        await Console.Out.WriteLineAsync($"Сообщение - [ {messageText} ] в чате - [ {chatId} ]");

        if (!_users.TryGetValue(chatId, out var userModel))
        {
            userModel = new UserModel();
            _users.Add(chatId, userModel);
        }

        if (messageText == "/start")
        {
            userModel.Reset();
            userModel.ResultModel.AddResult("Name", message.From.FirstName);
        }
        else if (_root.Successor[userModel.Node].Successor[userModel.Link].IsCallBack || !(userModel.IsStart))
        {
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Попробуйте заново или нажмите на /start",
                cancellationToken: cancellationToken);

            return;
        }

        if (userModel.CurrentState == State.Main)
        {
            await _botClient.SendVideoAsync(
                     chatId: chatId,
                     caption: _root.Successor[userModel.Node].Successor[userModel.Link].Text,
                     replyMarkup: _root.Successor[userModel.Node].Successor[userModel.Link].ReplyMarkup,
                     video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
                     thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"),
                     supportsStreaming: true,
                     cancellationToken: cancellationToken);
        }
        else if (userModel.CurrentState == State.Orders)
        {
            userModel.ResultModel.AddResult(_root.Successor[userModel.Node].Successor[userModel.Link].Name, messageText);
            userModel.MoveNext();

            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: _root.Successor[userModel.Node].Successor[userModel.Link].Text,
                replyMarkup: _root.Successor[userModel.Node].Successor[userModel.Link].ReplyMarkup,
                cancellationToken: cancellationToken);

        }
    }

    public async Task CallbackMessage(Update update, CancellationToken cancellationToken)
    {
        if (update.CallbackQuery is not { } callbackQuery)
            return;

        if (callbackQuery.Data is not { } data)
            return;

        var chatId = callbackQuery.Message.Chat.Id;

        if (!_users.TryGetValue(chatId, out UserModel userModel))
        {
            userModel = new UserModel();
            _users.Add(chatId, userModel);
        }

        if (!userModel.IsStart)
            return;

        if (_root.Successor[userModel.Node].Successor[userModel.Link].ReplyMarkup.InlineKeyboard.FirstOrDefault(s => s.Any(d => d.CallbackData == data)) == null)
        {
            await _botClient.SendTextMessageAsync(
               chatId: chatId,
               text: "Используйте команду /start",
               cancellationToken: cancellationToken);

            return;
        }

        await Console.Out.WriteLineAsync("Callback - " + data);

        switch (data)
        {
            case "Оформить":
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: CHAT_RESULT_ID,
                        text: userModel.ResultModel.ToResult(),
                        cancellationToken: cancellationToken);

                    userModel.MoveNext();
                }
                return;
            case "Быстрая доставка":
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Быстрая доставка - https://t.me/+oPRJKZnh_oUzYjk1",
                        cancellationToken: cancellationToken);

                }
                return;
            case "Перейти к товарам":
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Перейти к товарам -  https://t.me/TaoBaoRS",
                        cancellationToken: cancellationToken);

                }
                return;
            case "Отзывы о нашей работе":
                {
                    await _botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Отзывы о нашей работе - https://t.me/+KLLOcCSPVHoyNzE1",
                        cancellationToken: cancellationToken);

                }
                return;
            default:
                userModel.GetCallback(data);
                break;
        }

        var text = _root.Successor[userModel.Node].Successor[userModel.Link].Text;
        var markup = _root.Successor[userModel.Node].Successor[userModel.Link].ReplyMarkup;

        await Console.Out.WriteLineAsync("Text - " + text);

        if (userModel.CurrentState == State.Main)
        {
            await _botClient.SendVideoAsync(
                     chatId: chatId,
                     caption: text,
                     replyMarkup: markup,
                     video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
                     thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"),
                     supportsStreaming: true,
                     cancellationToken: cancellationToken);
        }
        else if (userModel.CurrentState == State.Orders)
        {
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: markup,
                cancellationToken: cancellationToken);
        }
        else if (userModel.CurrentState == State.Helps)
        {
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: markup,
                cancellationToken: cancellationToken);
        }
        else if (userModel.CurrentState == State.FAQs)
        {
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: markup,
                cancellationToken: cancellationToken);
        }

        await Task.Delay(1000, cancellationToken);
    }
}