namespace TelegramShopBot.Utils;

internal static class DataManager
{
    private const string _CONFIG_FILE_PATH = @"Resources/config.json";

    public static T GetConfigValue<T>(in string keyPath)
    {
        return JsonUtils.GetKeyValue<T>(FileUtils.ReadContent(_CONFIG_FILE_PATH), keyPath);
    }

    public static async Task<T> GetConfigValueAsync<T>(string keyPath)
    {
        string content = await FileUtils.ReadContentAsync(_CONFIG_FILE_PATH).ConfigureAwait(false);
        T result = JsonUtils.GetKeyValue<T>(content, keyPath);
        return result;
    }
}
