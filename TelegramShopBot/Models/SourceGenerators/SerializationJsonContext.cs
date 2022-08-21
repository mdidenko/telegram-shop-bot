using TelegramShopBot.Models.Telegram.Methods;
using TelegramShopBot.Models.Telegram.Types;

namespace TelegramShopBot.Models.SourceGenerators;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(AnswerCallbackQuery))]
[JsonSerializable(typeof(DeleteMessage))]
[JsonSerializable(typeof(DeleteMyCommands))]
[JsonSerializable(typeof(DeleteWebhook))]
[JsonSerializable(typeof(EditMessageReplyMarkup))]
[JsonSerializable(typeof(EditMessageText))]
[JsonSerializable(typeof(SendDocument))]
[JsonSerializable(typeof(SendMessage))]
[JsonSerializable(typeof(SendPhoto))]
[JsonSerializable(typeof(SetChatMenuButton))]
[JsonSerializable(typeof(SetMyCommands))]
[JsonSerializable(typeof(SetWebhook))]
[JsonSerializable(typeof(BotCommand))]
[JsonSerializable(typeof(BotCommandScopeAllPrivateChats))]
[JsonSerializable(typeof(BotCommandScopeChatAdministrators))]
[JsonSerializable(typeof(InlineKeyboardButton))]
[JsonSerializable(typeof(InlineKeyboardMarkup))]
[JsonSerializable(typeof(MenuButtonCommands))]
internal partial class SerializationJsonContext : JsonSerializerContext
{
}
