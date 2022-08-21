using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal class EditMessageReplyMarkup : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; private set; }

    [JsonPropertyName("message_id")]
    public int? MessageId { get; private set; }

    [JsonPropertyName("reply_markup")]
    public InlineKeyboardMarkup? ReplyMarkup { get; private set; }

    # region Constructor
    public EditMessageReplyMarkup()
    {
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.EditMessageReplyMarkup);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("editMessageReplyMarkup", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public EditMessageReplyMarkup SetChatId(in string chatId)
    {
        ChatId = chatId;
        return this;
    }

    public EditMessageReplyMarkup SetMessageId(in int messageId)
    {
        MessageId = messageId;
        return this;
    }

    public EditMessageReplyMarkup SetReplyMarkup(in InlineKeyboardMarkup replyMarkup)
    {
        ReplyMarkup = replyMarkup;
        return this;
    }
    # endregion
}
