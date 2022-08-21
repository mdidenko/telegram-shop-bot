using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

[Serializable]
internal sealed class InlineKeyboardButton : IJsonSerializable
{
    [JsonPropertyName("text")]
    public string Text { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; private set; }

    [JsonPropertyName("callback_data")]
    public string? CallbackData { get; private set; }

    # region Сonstructor
    public InlineKeyboardButton(in string text)
    {
        Text = text;
    }
    # endregion

    #region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.InlineKeyboardButton);
    }
    # endregion

    #region Fluent setters
    public InlineKeyboardButton SetUrl (in string url)
    {
        Url = url;
        return this;
    }

    public InlineKeyboardButton SetCallbackData(in string callbackData)
    {
        CallbackData = callbackData;
        return this;
    }
    # endregion
}
