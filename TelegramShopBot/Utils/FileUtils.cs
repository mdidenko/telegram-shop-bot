using System.IO;

namespace TelegramShopBot.Utils;

internal static class FileUtils
{
    public static string ReadContent(in string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception during synchronous content reading from file.", ex)
                .AddParameter(nameof(filePath), filePath);
        }
    }

    public static async Task<string> ReadContentAsync(string filePath)
    {
        string content;
        try
        {
            content = await File.ReadAllTextAsync(filePath).ConfigureAwait(false);
        } 
        catch (Exception ex)
        {
            throw new Exception("Exception during asynchronous content reading from file.", ex)
                .AddParameter(nameof(filePath), filePath);
        }
        return content;
    }

    public static async Task WriteContentAsync(string filePath, string content)
    {
        try
        {
            await File.WriteAllTextAsync(filePath, content).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception during asynchronous content writing to file.", ex)
                .AddParameter(nameof(filePath), filePath)
                .AddParameter(nameof(content), content);
        }
    }
}
