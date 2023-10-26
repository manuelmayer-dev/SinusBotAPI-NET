using System.Net.Http.Json;
using SinusBotAPI.DataTypes.V1.Response;

namespace SinusBotAPI;

internal static class HttpClientHelper
{
    public static HttpClient GetHttpClient()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "SinusBotAPI-NET/1.0");
        httpClient.DefaultRequestHeaders.Add("Accept", "Application/Json");
        return httpClient;
    }
    
    public static HttpClient GetHttpClientAuthorizationHeader(string? bearerToken)
    {
        if (string.IsNullOrWhiteSpace(bearerToken))
        {
            throw new SinusBotApiException(ErrorCode.NotAuthenticated);
        }
        
        var httpClient = GetHttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
        return httpClient;
    }

    public static async Task<T> GetJson<T>(string url, string? bearerToken)
    {
        var task = GetHttpClientAuthorizationHeader(bearerToken).GetAsync(url);
        var response = await TryHttpTask(task);
        return await response.Content.ReadFromJsonAsync<T>()
               ?? throw new SinusBotApiException(ErrorCode.UnexpectedDataReceived);
    }
    
    public static async Task Delete<T>(string url, string? bearerToken)
        where T : BaseSuccessResponse
    {
        var task = GetHttpClientAuthorizationHeader(bearerToken).DeleteAsync(url);
        var response = await TryHttpTask(task);
        var successResponse = await response.Content.ReadFromJsonAsync<T>();
        successResponse.EnsureSuccessful();
    }

    public static async Task Post<T>(string url, string? bearerToken)
        where T : BaseSuccessResponse
    {
        var task = GetHttpClientAuthorizationHeader(bearerToken).PostAsync(url, new StringContent(string.Empty));
        var response = await TryHttpTask(task);
        var successResponse = await response.Content.ReadFromJsonAsync<T>();
        successResponse.EnsureSuccessful();
    }

    public static async Task<T> PostJson<T>(string url, object request, string? bearerToken)
        where T : BaseSuccessResponse
    {
        var task = GetHttpClientAuthorizationHeader(bearerToken).PostAsJsonAsync(url, request);
        var response = await TryHttpTask(task);
        var successResponse = await response.Content.ReadFromJsonAsync<T>();
        return successResponse.EnsureSuccessful();
    }

    public static async Task PatchJson<T>(string url, object request, string? bearerToken)
        where T : BaseSuccessResponse
    {
        var task = GetHttpClientAuthorizationHeader(bearerToken).PatchAsJsonAsync(url, request);
        var response = await TryHttpTask(task);
        var successResponse = await response.Content.ReadFromJsonAsync<T>();
        successResponse.EnsureSuccessful();
    }

    private static async Task<HttpResponseMessage> TryHttpTask(Task<HttpResponseMessage> task)
    {
        try
        {
            var result = await task;
            return result.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException httpRequestException)
        {
            throw new SinusBotApiException(httpRequestException.StatusCode.ToErrorCode());
        }
    }
}