using TelegramShopBot.Models.Telegram.Types;

namespace TelegramShopBot.Models.SourceGenerators;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(Document))]
internal partial class DefaultJsonContext : JsonSerializerContext
{
}
