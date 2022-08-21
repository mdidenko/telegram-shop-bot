using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

[Serializable]
internal sealed class BotCommandScopeAllPrivateChats : BotCommandScope, IJsonSerializable
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = "all_private_chats";

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.BotCommandScopeAllPrivateChats);
    }
    # endregion
}
