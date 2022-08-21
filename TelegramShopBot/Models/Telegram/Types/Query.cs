using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

internal sealed class Query
{
    [JsonPropertyName("message")]
    public Message? Message { get; set; }

    [JsonPropertyName("callback_query")]
    public CallbackQuery? CallbackQuery { get; set; }

    #region Implementation for deserialization with source code generators
    public static Query GetObjectFromJson(in string json)
    {
        return JsonUtils.Deserialize(json, MetadataJsonContext.Default.Query);
    }
    # endregion
}
