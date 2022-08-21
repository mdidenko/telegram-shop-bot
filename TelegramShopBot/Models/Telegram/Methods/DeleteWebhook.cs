using TelegramShopBot.Models.Abstractions;
using TelegramShopBot.Models.SourceGenerators;
using TelegramShopBot.Models.Telegram.Abstractions;
using TelegramShopBot.Models.Telegram.Types;
using TelegramShopBot.Utils;

namespace TelegramShopBot.Models.Telegram.Methods;

[Serializable]
internal sealed class DeleteWebhook : IJsonSerializable, ITelegramRequest
{
    [JsonPropertyName("drop_pending_updates")]
    public bool? DropPendingUpdates { get; private set; }

    # region Constructor
    public DeleteWebhook() 
    {
    }
    # endregion

    # region IJsonSerializable realization
    public string SerializeToJson()
    {
        return JsonUtils.Serialize(this, SerializationJsonContext.Default.DeleteWebhook);
    }
    # endregion

    #region ITelegramRequest realization
    public Task<Answer> SendRequestAsync()
    {
        return TelegramBotUtils.SendRequestAsync("deleteWebhook", SerializeToJson());
    }
    # endregion

    # region Fluent setters
    public DeleteWebhook SetDropPendingUpdate(in bool dropPendingUpdates)
    {
        DropPendingUpdates = dropPendingUpdates;
        return this;
    }
    # endregion
}
