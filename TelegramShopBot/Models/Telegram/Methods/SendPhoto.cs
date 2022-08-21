using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class SendPhoto : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public string ChatId { get; init; }

    [JsonPropertyName("photo")]
    public string Photo { get; init; }

    [JsonPropertyName("caption")]
    public string? Caption { get; private set; }

    [JsonPropertyName("parse_mode")]
    public string? ParseMode { get; private set; }

    [JsonPropertyName("disable_notification")]
    public bool? DisableNotification { get; private set; }

    [JsonPropertyName("protect_content")]
    public bool? ProtectContent { get; private set; }

    [JsonPropertyName("reply_markup")]
    public InlineKeyboardMarkup? ReplyMarkup { get; private set; }

    # region Сonstructor
    public SendPhoto(in string chatId, in string photo)
    {
        ChatId = chatId;
        Photo = photo;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.SendPhoto);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("sendPhoto", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public SendPhoto SetCaption(in string caption)
    {
        Caption = caption;
        return this;
    }

    public SendPhoto SetParseMode(in string parseMode)
    {
        ParseMode = parseMode;
        return this;
    }

    public SendPhoto SetDisableNotification(in bool disableNotification)
    {
        DisableNotification = disableNotification;
        return this;
    }

    public SendPhoto SetProtectContent(in bool protectContent)
    {
        ProtectContent = protectContent;
        return this;
    }

    public SendPhoto SetReplyMarkup(in InlineKeyboardMarkup replyMarkup)
    {
        ReplyMarkup = replyMarkup;
        return this;
    }
    # endregion
}
