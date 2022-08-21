using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class SetChatMenuButton : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("chat_id")]
    public int? ChatId { get; private set; }

    [JsonPropertyName("menu_button")]
    public MenuButton? MenuButton { get; private set; }

    # region Сonstructor
    public SetChatMenuButton()
    {
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.SetChatMenuButton);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("setChatMenuButton", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public SetChatMenuButton SetChatId(in int chatId)
    {
        ChatId = chatId;
        return this;
    }

    public SetChatMenuButton SetMenuButton(in MenuButton menuButton)
    {
        MenuButton = menuButton;
        return this;
    }
    # endregion
}
