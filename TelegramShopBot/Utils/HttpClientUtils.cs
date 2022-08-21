using System.Text;
using TelegramShopBot.Models;

namespace TelegramShopBot.Utils;

internal static class HttpClientUtils
{
    private static readonly HttpClient s_httpClient = new HttpClient(new SocketsHttpHandler());

    private static async Task<RestApiResponse> ConvertJsonHttpResponseAsync(HttpResponseMessage response)
    {
        string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return new RestApiResponse(response.StatusCode, content);
    }

    public static async Task<RestApiResponse> SendPostRequestAsync(string url, string body, string mediaType = "application/json")
    {
        HttpResponseMessage httpResponseMessage;
        HttpContent content = new StringContent(body, Encoding.UTF8, mediaType);

        try
        {
            httpResponseMessage = await s_httpClient.PostAsync(url, content).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception when sending asynchronous post request.", ex)
                .AddParameter(nameof(url), url)
                .AddParameter(nameof(body), body);
        }
        finally
        {
            content.Dispose();
        }

        var result = await ConvertJsonHttpResponseAsync(httpResponseMessage).ConfigureAwait(false);
        return result;
    }
}
