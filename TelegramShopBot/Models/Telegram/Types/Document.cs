using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

internal sealed class Document : IJsonSerializable
{
    [JsonPropertyName("file_id")]
    public string FileId { get; set; }

    #region Сonstructor
    public Document(in string fileId)
    {
        FileId = fileId;
    }
    #endregion

    #region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, DefaultJsonContext.Default.Document);
    }
    # endregion

    #region Implementation for deserialization with source code generators
    public static Document GetObjectFromJson(in string json)
    {
        return JsonUtils.Deserialize(json, DefaultJsonContext.Default.Document);
    }
    # endregion
}
