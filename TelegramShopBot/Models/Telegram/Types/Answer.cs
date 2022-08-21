using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

internal sealed class Answer
{
    // Warning: not implemented!

    #region Implementation for deserialization with source code generators
    public static Answer GetObjectFromJson(in string json)
    {
        return JsonUtils.Deserialize(json, MetadataJsonContext.Default.Answer);
    }
    # endregion
}
