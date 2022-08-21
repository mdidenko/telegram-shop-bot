using TelegramShopBot.Models.Telegram.Types;

namespace TelegramShopBot.Models.SourceGenerators;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(Answer))]
[JsonSerializable(typeof(CallbackQuery))]
[JsonSerializable(typeof(Chat))]
[JsonSerializable(typeof(Message))]
[JsonSerializable(typeof(MessageEntity))]
[JsonSerializable(typeof(PhotoSize))]
[JsonSerializable(typeof(Query))]
[JsonSerializable(typeof(User))]
internal partial class MetadataJsonContext : JsonSerializerContext
{
}
