using Telegram.Bot.Types.ReplyMarkups;

namespace TgJourneyBot.Core.Service.Abstract;

public abstract class Handler
{
    public List<Handler>? Successor;

    public string Name;
    public bool IsCallBack;
    public abstract string? Text { get; set; }
    public abstract InlineKeyboardMarkup ReplyMarkup { get; set; }
}
