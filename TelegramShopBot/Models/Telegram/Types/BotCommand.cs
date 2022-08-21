using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

[Serializable]
internal sealed class BotCommand : IJsonSerializable
{
    [JsonPropertyName("command")]
    public string Command { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    # region Сonstructor
    public BotCommand(in string command, in string description)
    {
        Command = command;
        Description = description;
    }
    #endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.BotCommand);
    }
    # endregion
}
