using SinusBotAPI.DataTypes.V1.Response;

namespace SinusBotAPI;

public static class BaseSuccessResponseExtensions
{
    public static T EnsureSuccessful<T>(this T? response)
        where T : BaseSuccessResponse
    {
        if (response is null || !response.Success)
        {
            throw new SinusBotApiException(ErrorCode.ActionNotSuccessful);
        }

        return response;
    }
}