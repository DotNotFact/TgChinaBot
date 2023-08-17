using Telegram.Bot.Types.ReplyMarkups;
using TgJourneyBot.Core.Service.Abstract;

namespace TgJourneyBot.Core.Service.Implement;

class HandlerImplement : Handler
{
    public override string? Text { get; set; }
    public override InlineKeyboardMarkup? ReplyMarkup { get; set; }
}