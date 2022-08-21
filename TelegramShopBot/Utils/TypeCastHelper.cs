namespace TelegramShopBot.Utils;

internal static class TypeCastHelper
{
    public static TDesired ConvertType<TDesired>(in string value)
    {
        try
        {
            return (TDesired)Convert.ChangeType(value, typeof(TDesired));
        }
        catch (Exception ex)
        {
            throw new Exception("Exception during type conversion.", ex)
                .AddParameter(nameof(TDesired), typeof(TDesired).Name)
                .AddParameter(nameof(value), value);
        }
    }
}
