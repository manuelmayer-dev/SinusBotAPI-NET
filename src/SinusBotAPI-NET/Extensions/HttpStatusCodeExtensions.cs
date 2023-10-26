using System.Net;

namespace SinusBotAPI;

public static class HttpStatusCodeExtensions
{
    public static ErrorCode ToErrorCode(this HttpStatusCode? statusCode)
    {
        switch (statusCode)
        {
            case HttpStatusCode.BadGateway:
            case HttpStatusCode.ServiceUnavailable:
            case HttpStatusCode.GatewayTimeout:
            case HttpStatusCode.Gone:
            case HttpStatusCode.NotFound:
            case HttpStatusCode.RequestTimeout:
            case HttpStatusCode.TooManyRequests:
                return ErrorCode.BotNotFound;
            
            case HttpStatusCode.InternalServerError:
                return ErrorCode.ServerError;
            
            case HttpStatusCode.Forbidden:
                return ErrorCode.NoPermission;
                
            case HttpStatusCode.Unauthorized:
                return ErrorCode.NotAuthenticated;
            
            case HttpStatusCode.BadRequest:
                return ErrorCode.BadRequest;
                
            default:
                return ErrorCode.UnknownError;
        }
    }
}