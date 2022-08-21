using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class SendDocument : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public string ChatId { get; init; }

    [JsonPropertyName("document")]
    public string Document { get; init; }

    [JsonPropertyName("caption")]
    public string? Caption { get; private set; }

    [JsonPropertyName("parse_mode")]
    public string? ParseMode { get; private set; }

    [JsonPropertyName("disable_content_type_detection")]
    public bool? DisableContentTypeDetection { get; private set; }

    [JsonPropertyName("disable_notification")]
    public bool? DisableNotification { get; private set; }

    [JsonPropertyName("protect_content")]
    public bool? ProtectContent { get; private set; }

    [JsonPropertyName("reply_markup")]
    public InlineKeyboardMarkup? ReplyMarkup { get; private set; }

    # region Сonstructor
    public SendDocument(in string chatId, in string document)
    {
        ChatId = chatId;
        Document = document;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.SendDocument);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("sendDocument", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public SendDocument SetCaption(in string caption)
    {
        Caption = caption;
        return this;
    }

    public SendDocument SetParseMode(in string parseMode)
    {
        ParseMode = parseMode;
        return this;
    }

    public SendDocument SetDisableContentTypeDetection(in bool disableContentTypeDetection)
    {
        DisableContentTypeDetection = disableContentTypeDetection;
        return this;
    }

    public SendDocument SetDisableNotification(in bool disableNotification)
    {
        DisableNotification = disableNotification;
        return this;
    }

    public SendDocument SetProtectContent(in bool protectContent)
    {
        ProtectContent = protectContent;
        return this;
    }

    public SendDocument SetReplyMarkup(in InlineKeyboardMarkup replyMarkup)
    {
        ReplyMarkup = replyMarkup;
        return this;
    }
    # endregion
}
