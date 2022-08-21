using TelegramShopBot.Models;
using TelegramShopBot.Models.Telegram.Types;

namespace TelegramShopBot.Utils;

internal static class TelegramBotUtils
{
    public static async Task<Answer> SendRequestAsync(string methodName, string data)
    {
        string botToken = await DataManager.GetConfigValueAsync<string>("bot.token").ConfigureAwait(false);
        string url = $"https://api.telegram.org/bot{botToken}/{methodName}";
        RestApiResponse result = await HttpClientUtils.SendPostRequestAsync(url, data).ConfigureAwait(false);
        if (!result.isOk())
        {
            throw new Exception("Exception when sending request to telegram bot.")
                .AddParameter(nameof(methodName), methodName)
                .AddParameter(nameof(data), data)
                .AddParameter("apiMessage", result.Body);
        }
        return Answer.GetObjectFromJson(result.Body);
    }
}
