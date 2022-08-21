using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class DeleteMessage : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public string ChatId { get; init; }

    [JsonPropertyName("message_id")]
    public int MessageId { get; init; }

    # region Constructor
    public DeleteMessage(in string chatId, in int messageId)
    {
        ChatId = chatId;
        MessageId = messageId;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.DeleteMessage);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("deleteMessage", SerializeToJson());
    }
    # endregion
}
