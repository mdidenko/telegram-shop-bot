using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class SendMessage : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public string ChatId { get; init; }

    [JsonPropertyName("text")]
    public string Text { get; init; }

    [JsonPropertyName("parse_mode")]
    public string? ParseMode { get; private set; }

    [JsonPropertyName("disable_web_page_preview")]
    public bool? DisableWebPagePreview { get; private set; }

    [JsonPropertyName("disable_notification")]
    public bool? DisableNotification { get; private set; }

    [JsonPropertyName("protect_content")]
    public bool? ProtectContent { get; private set; }

    [JsonPropertyName("reply_to_message_id")]
    public int? ReplyToMessageId { get; private set; }

    [JsonPropertyName("allow_sending_without_reply")]
    public bool? AllowSendingWithoutReply { get; private set; }

    [JsonPropertyName("reply_markup")]
    public InlineKeyboardMarkup? ReplyMarkup { get; private set; }

    # region Сonstructor
    public SendMessage(in string chatId, in string text)
    {
        ChatId = chatId;
        Text = text;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.SendMessage);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("sendMessage", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public SendMessage SetParseMode(in string parseMode)
    {
        ParseMode = parseMode;
        return this;
    }

    public SendMessage SetDisableWebPagePreview(in bool disableWebPagePreview)
    {
        DisableWebPagePreview = disableWebPagePreview;
        return this;
    }

    public SendMessage SetDisableNotification(in bool disableNotification)
    {
        DisableNotification = disableNotification;
        return this;
    }

    public SendMessage SetProtectContent(in bool protectContent)
    {
        ProtectContent = protectContent;
        return this;
    }

    public SendMessage SetReplyToMessageId(in int replyToMessageId)
    {
        ReplyToMessageId = replyToMessageId;
        return this;
    }

    public SendMessage SetAllowSendingWithoutReply(in bool allowSendingWithoutReply)
    {
        AllowSendingWithoutReply = allowSendingWithoutReply;
        return this;
    }

    public SendMessage SetReplyMarkup(in InlineKeyboardMarkup replyMarkup)
    {
        ReplyMarkup = replyMarkup;
        return this;
    }
    # endregion
}
