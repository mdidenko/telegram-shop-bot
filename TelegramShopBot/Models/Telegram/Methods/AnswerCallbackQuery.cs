using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class AnswerCallbackQuery : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("callback_query_id")]
    public string CallbackQueryId { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; private set; }

    [JsonPropertyName("show_alert")]
    public bool? ShowAlert { get; private set; }

    [JsonPropertyName("url")]
    public string? Url { get; private set; }

    [JsonPropertyName("cache_time")]
    public int? CacheTime { get; private set; }

    # region Constructor 
    public AnswerCallbackQuery(in string callbackQueryId)
    {
        CallbackQueryId = callbackQueryId;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.AnswerCallbackQuery);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("answerCallbackQuery", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public AnswerCallbackQuery SetText(in string text)
    {
        Text = text;
        return this;
    }

    public AnswerCallbackQuery SetShowAlert(in bool showAlert)
    {
        ShowAlert = showAlert;
        return this;
    }

    public AnswerCallbackQuery SetUrl(in string url)
    {
        Url = url;
        return this;
    }

    public AnswerCallbackQuery SetCacheTime(in int cacheTime)
    {
        CacheTime = cacheTime;
        return this;
    }
    #endregion
}
