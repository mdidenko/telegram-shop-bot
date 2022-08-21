using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

[Serializable]
internal sealed class MenuButtonCommands : MenuButton, IJsonSerializable
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = "commands";

    #region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.MenuButtonCommands);
    }
    # endregion
}
