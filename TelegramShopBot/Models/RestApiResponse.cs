using System.Net;

namespace TelegramShopBot.Models;

internal class RestApiResponse
{
    private readonly HttpStatusCode _statusCode;
    private readonly string _body;

    public string Body
    {
        get { return _body; }
    }

    public RestApiResponse(in HttpStatusCode statusCode, in string body)
    {
        _statusCode = statusCode;
        _body = body;
    }

    public bool isOk()
    {
        return _statusCode == HttpStatusCode.OK;
    }
}
