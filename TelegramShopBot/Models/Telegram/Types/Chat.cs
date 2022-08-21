using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

internal sealed class Chat
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    #region Implementation for deserialization with source code generators
    public static Chat GetObjectFromJson(in string json)
    {
        return JsonUtils.Deserialize(json, MetadataJsonContext.Default.Chat);
    }
    # endregion
}
