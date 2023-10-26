using System.Net;
using System.Net.Http.Json;
using SinusBotAPI.DataTypes.V1;
using SinusBotAPI.DataTypes.V1.Request.FileList;
using SinusBotAPI.DataTypes.V1.Request.General;
using SinusBotAPI.DataTypes.V1.Request.Instance;
using SinusBotAPI.DataTypes.V1.Request.Playback;
using SinusBotAPI.DataTypes.V1.Response.FileList;
using SinusBotAPI.DataTypes.V1.Response.General;
using SinusBotAPI.DataTypes.V1.Response.Instance;
using SinusBotAPI.DataTypes.V1.Response.Playback;

namespace SinusBotAPI;

public class SinusBotClientClient : ISinusBotClient
{
    private const string ApiV1UrlSegment = "/api/v1";

    private string BotUrl { get; }

    private string ApiV1Url => BotUrl.AppendString(ApiV1UrlSegment);

    private string ApiV1BotUrl => ApiV1Url.AppendString("/bot");

    private string? BearerToken { get; set; }

    public SinusBotClientClient(string botUrl)
    {
        BotUrl = botUrl;
    }

    public async Task<string> GetBotId()
    {
        try
        {
            var botIdResponse = await HttpClientHelper.GetHttpClient()
                .GetFromJsonAsync<BotIdResponse>(ApiV1Url.AppendString("/botId"));
            return botIdResponse?.DefaultBotId ?? throw new SinusBotApiException(ErrorCode.UnexpectedDataReceived);
        }
        catch (HttpRequestException httpRequestException)
        {
            throw new SinusBotApiException(httpRequestException.StatusCode.ToErrorCode());
        }
    }

    public async Task Authenticate(string userName, string password)
    {
        var botId = await GetBotId();
        var loginRequest = new LoginRequest
        {
            Username = userName,
            Password = password,
            BotId = botId
        };
        try
        {
            var response = await HttpClientHelper.GetHttpClient()
                .PostAsJsonAsync(ApiV1BotUrl.AppendString("/login"), loginRequest);
            response.EnsureSuccessStatusCode();
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            if (loginResponse?.Success is false || string.IsNullOrWhiteSpace(loginResponse?.Token))
            {
                throw new SinusBotApiException(ErrorCode.UnexpectedDataReceived);
            }

            BearerToken = loginResponse.Token;
        }
        catch (HttpRequestException httpRequestException)
        {
            if (httpRequestException.StatusCode is HttpStatusCode.Unauthorized)
            {
                throw new SinusBotApiException(ErrorCode.WrongUserNameOrPassword);
            }

            throw new SinusBotApiException(httpRequestException.StatusCode.ToErrorCode());
        }
    }

    #region Instance

    public async Task<CreateInstanceResponse> CreateInstance(CreateInstanceRequest createInstanceRequest)
    {
        return await HttpClientHelper.PostJson<CreateInstanceResponse>(ApiV1BotUrl.AppendString("/instances"),
            createInstanceRequest, BearerToken);
    }

    public async Task DeleteInstance(string uuid)
    {
        await HttpClientHelper.Delete<DeleteInstanceResponse>(
            ApiV1BotUrl.AppendString("/instances/").AppendString(uuid), BearerToken);
    }

    public async Task StartInstance(string uuid)
    {
        await HttpClientHelper.Post<SpawnInstanceResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(uuid).AppendString("/spawn"), BearerToken);
    }

    public async Task RestartInstance(string uuid)
    {
        await HttpClientHelper.Post<RespawnInstanceResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(uuid).AppendString("/respawn"), BearerToken);
    }

    public async Task ShutdownInstance(string uuid)
    {
        await HttpClientHelper.Post<RespawnInstanceResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(uuid).AppendString("/kill"), BearerToken);
    }

    public async Task<InstanceStatusResponse> GetInstanceStatus(string uuid)
    {
        return await HttpClientHelper.GetJson<InstanceStatusResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(uuid).AppendString("/status"), BearerToken);
    }

    public async Task UpdateSettings(UpdateSettingsRequest updateSettingsRequest)
    {
        await HttpClientHelper.PostJson<UpdateSettingsResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(updateSettingsRequest.InstanceId).AppendString("/settings"),
            updateSettingsRequest, BearerToken);
    }

    public async Task<List<InstanceData>> GetInstances()
    {
        return await HttpClientHelper.GetJson<List<InstanceData>>(ApiV1BotUrl.AppendString("/instances"), BearerToken);
    }

    #endregion

    #region Filelist

    public async Task AddFileListUrl(AddUrlRequest addUrlRequest)
    {
        await HttpClientHelper.PostJson<AddUrlResponse>(ApiV1BotUrl.AppendString("/url"), addUrlRequest, BearerToken);
    }

    public async Task CreateFileListFolder(CreateFolderRequest createFolderRequest)
    {
        await HttpClientHelper.PostJson<CreateFolderResponse>(ApiV1BotUrl.AppendString("/folders"), createFolderRequest,
            BearerToken);
    }

    public async Task DeleteFile(string uuid)
    {
        await HttpClientHelper.Delete<DeleteFileResponse>(ApiV1BotUrl.AppendString("/files/").AppendString(uuid),
            BearerToken);
    }

    public async Task<List<FileData>> GetFiles()
    {
        return await HttpClientHelper.GetJson<List<FileData>>(ApiV1BotUrl.AppendString("/files"), BearerToken);
    }

    public async Task UpdateFile(UpdateFileRequest updateFileRequest)
    {
        await HttpClientHelper.PatchJson<UpdateFileResponse>(
            ApiV1BotUrl.AppendString("/files/").AppendString(updateFileRequest.Id), updateFileRequest, BearerToken);
    }

    #endregion

    #region Playback

    public async Task DecreaseVolume(string instanceUuid)
    {
        await HttpClientHelper.Post<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/volume/down"), BearerToken);
    }

    public async Task IncreaseVolume(string instanceUuid)
    {
        await HttpClientHelper.Post<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/volume/up"), BearerToken);
    }

    public async Task MuteUnmuteVolume(string instanceUuid, bool mute)
    {
        await HttpClientHelper.Post<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/mute/")
                .AppendString(mute ? "1" : "0"), BearerToken);
    }

    public async Task PausePlayback(string instanceUuid)
    {
        await HttpClientHelper.Post<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/pause"), BearerToken);
    }

    public async Task PlaybackUrl(string instanceUuid, string url)
    {
        await HttpClientHelper.Post<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/playUrl?url=").AppendString(url),
            BearerToken);
    }

    public async Task PlaybackFileInPlaylist(string instanceUuid, string playListUuid, int index)
    {
        await HttpClientHelper.Post<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/play/byList/")
                .AppendString(playListUuid).AppendString("/").AppendString(index.ToString()), BearerToken);
    }

    public async Task PlaybackFile(string instanceUuid, string fileId)
    {
        await HttpClientHelper.Post<PlaybackResponse>(ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid)
            .AppendString("/play/byId/").AppendString(fileId), BearerToken);
    }

    public async Task Say(TtsRequest ttsRequest)
    {
        await HttpClientHelper.PostJson<PlaybackResponse>(
            ApiV1BotUrl.AppendString("/i/").AppendString(ttsRequest.InstanceId).AppendString("/say"), ttsRequest,
            BearerToken);
    }

    public async Task PlaybackSeek(string instanceUuid, int value)
    {
        await HttpClientHelper.Post<PlaybackResponse>(ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid)
            .AppendString("/seek/").AppendString(value.ToString()), BearerToken);
    }

    public async Task SetVolumePercent(string instanceUuid, int value)
    {
        if (value is < 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "The value must be between 0 and 100");
        }

        await HttpClientHelper.Post<PlaybackResponse>(ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid)
            .AppendString("/value/set/").AppendString(value.ToString()), BearerToken);
    }

    public async Task StopPlayback(string instanceUuid)
    {
        await HttpClientHelper.Post<PlaybackResponse>(ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid)
            .AppendString("/stop"), BearerToken);
    }

    public async Task<List<string>> GetRecentlyPlayedTracks(string instanceUuid)
    {
        return await HttpClientHelper.GetJson<List<string>>(
            ApiV1BotUrl.AppendString("/i/").AppendString(instanceUuid).AppendString("/recent"), BearerToken);
    }
    
    #endregion

}