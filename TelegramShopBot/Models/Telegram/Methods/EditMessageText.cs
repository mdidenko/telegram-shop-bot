using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class EditMessageText : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; private set; }

    [JsonPropertyName("message_id")]
    public int? MessageId { get; private set; }

    [JsonPropertyName("text")]
    public string Text { get; init; }

    [JsonPropertyName("parse_mode")]
    public string? ParseMode { get; private set; }

    [JsonPropertyName("disable_web_page_preview")]
    public bool? DisableWebPagePreview { get; private set; }

    [JsonPropertyName("reply_markup")]
    public InlineKeyboardMarkup? ReplyMarkup { get; private set; }

    # region Сonstructor
    public EditMessageText(in string text)
    {
        Text = text;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.EditMessageText);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("editMessageText", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public EditMessageText SetChatId(in string chatId)
    {
        ChatId = chatId;
        return this;
    }

    public EditMessageText SetMessageId(in int messageId)
    {
        MessageId = messageId;
        return this;
    }

    public EditMessageText SetParseMode(in string parseMode)
    {
        ParseMode = parseMode;
        return this;
    }

    public EditMessageText SetDisableWebPagePreview(in bool disableWebPagePreview)
    {
        DisableWebPagePreview = disableWebPagePreview;
        return this;
    }

    public EditMessageText SetReplyMarkup(in InlineKeyboardMarkup replyMarkup)
    {
        ReplyMarkup = replyMarkup;
        return this;
    }
    # endregion
}
