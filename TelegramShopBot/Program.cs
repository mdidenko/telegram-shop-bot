using System.Collections;

namespace TelegramShopBot;

internal class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Warning: not implemented!
        }
        catch (Exception ex)
        {
            # region Environment for test exception handler
            string exceptionMessage = ex.Message;
            if (ex.InnerException != null)
            {
                string innerExceptionMessage = ex.InnerException.Message;
                if (innerExceptionMessage != string.Empty)
                {
                    exceptionMessage = $"{exceptionMessage} {innerExceptionMessage}";
                }
            }
            Console.WriteLine(exceptionMessage);
            foreach(DictionaryEntry entry in ex.Data)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            # endregion
        }

        await Task.CompletedTask;
    }
}
