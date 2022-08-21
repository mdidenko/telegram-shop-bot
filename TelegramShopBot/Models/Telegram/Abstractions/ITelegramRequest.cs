using TelegramShopBot.Models.Telegram.Types;

namespace TelegramShopBot.Models.Telegram.Abstractions;

internal interface ITelegramRequest
{
    public Task<Answer> SendRequestAsync();
}
