using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class SetMyCommands : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("commands")]
    public BotCommand[] Commands { get; init; }

    [JsonPropertyName("scope")]
    public BotCommandScope? Scope { get; private set; }

    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; private set; }

    # region Сonstructor
    public SetMyCommands(in BotCommand[] commands)
    {
        Commands = commands;
    }
    # endregion 

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.SetMyCommands);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("setMyCommands", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public SetMyCommands SetScope(in BotCommandScope scope)
    {
        Scope = scope;
        return this;
    }

    public SetMyCommands SetLanguageCode(in string languageCode)
    {
        LanguageCode = languageCode;
        return this;
    }
    # endregion
}
