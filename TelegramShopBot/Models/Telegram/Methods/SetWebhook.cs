using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class SetWebhook : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("url")]
    public string Url { get; init; }

    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; private set; }

    [JsonPropertyName("max_connections")]
    public int? MaxConnections { get; private set; }

    [JsonPropertyName("allowed_updates")]
    public string[]? AllowedUpdates { get; private set; }

    [JsonPropertyName("drop_pending_updates")]
    public bool? DropPendingUpdates { get; private set; }

    # region Сonstructor
    public SetWebhook(in string url)
    {
        Url = url;
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.SetWebhook);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("setWebhook", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public SetWebhook SetIpAddress(in string ipAddress)
    {
        IpAddress = ipAddress;
        return this;
    }

    public SetWebhook SetMaxConnections(in int maxConnections)
    {
        MaxConnections = maxConnections;
        return this;
    }

    public SetWebhook SetAllowedUpdates(in string[] allowedUpdates)
    {
        AllowedUpdates = allowedUpdates;
        return this;
    }

    public SetWebhook SetDropPendingUpdates(in bool dropPendingUpdates)
    {
        DropPendingUpdates = dropPendingUpdates;
        return this;
    }
    # endregion
}
