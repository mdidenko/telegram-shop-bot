using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Types;

[Serializable]
internal sealed class InlineKeyboardMarkup : IJsonSerializable
{
    [JsonPropertyName("inline_keyboard")]
    public InlineKeyboardButton[][] InlineKeyboard { get; init; }

    # region Сonstructor
    public InlineKeyboardMarkup(in InlineKeyboardButton[][] inlineKeyboard)
    {
        InlineKeyboard = inlineKeyboard;
    }
    # endregion

    #region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.InlineKeyboardMarkup);
    }
    # endregion
}
