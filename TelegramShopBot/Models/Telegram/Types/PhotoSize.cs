using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

internal sealed class PhotoSize
{
    [JsonPropertyName("file_id")]
    public string FileId { get; set; }

    [JsonPropertyName("width")]
    public string Width { get; set; }

    [JsonPropertyName("height")]
    public string Height { get; set; }

    #region Implementation for deserialization with source code generators
    public static PhotoSize GetObjectFromJson(in string json)
    {
        return JsonUtils.Deserialize(json, MetadataJsonContext.Default.PhotoSize);
    }
    # endregion
}
