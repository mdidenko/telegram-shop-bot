using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

[Serializable]
internal sealed class BotCommandScopeChatAdministrators : BotCommandScope, IJsonSerializable
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = "chat_administrators";

    [JsonPropertyName("chat_id")]
    public string ChatId { get; init; }

    #region Сonstructor
    public BotCommandScopeChatAdministrators(in string chatId)
    {
        ChatId = chatId;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.BotCommandScopeChatAdministrators);
    }
    # endregion
}
