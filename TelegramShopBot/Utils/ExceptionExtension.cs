namespace TelegramShopBot.Utils;

internal static class ExceptionExtension
{
    public static Exception AddParameter(this Exception exception, in string key, in string? value)
    {
        try
        {
            exception.Data.Add(key, value);
        }
        catch (Exception ex) when (ex is ArgumentNullException or ArgumentException or NotSupportedException)
        {
            throw new Exception($"Exception while adding parameter in exception.\nkey: {key}\nvalue: {value}", ex);
        }
        return exception;
    }
}
