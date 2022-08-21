using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

internal sealed class Message
{
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }

    [JsonPropertyName("from")]
    public User From { get; set; }

    [JsonPropertyName("chat")]
    public Chat Chat { get; set; }

    [JsonPropertyName("date")]
    public int Date { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("photo")]
    public PhotoSize[]? Photo { get; set; }

    [JsonPropertyName("document")]
    public Document? Document { get; set; }

    #region Implementation for deserialization with source code generators
    public static Message GetObjectFromJson(in string json)
    {
        return JsonUtils.Deserialize(json, MetadataJsonContext.Default.Message);
    }
    # endregion
}
