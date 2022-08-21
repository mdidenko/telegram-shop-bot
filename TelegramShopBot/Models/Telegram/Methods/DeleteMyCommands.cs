using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class DeleteMyCommands : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("scope")]
    public BotCommandScope? Scope { get; private set; }

    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; private set; }

    # region Constructor
    public DeleteMyCommands() 
    {
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.DeleteMyCommands);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("deleteMyCommands", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public DeleteMyCommands SetScope(in BotCommandScope scope)
    {
        Scope = scope;
        return this;
    }

    public DeleteMyCommands SetLanguageCode(in string languageCode)
    {
        LanguageCode = languageCode;
        return this;
    }
    # endregion
}
