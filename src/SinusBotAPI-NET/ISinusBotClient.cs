using SinusBotAPI.DataTypes.V1;
using SinusBotAPI.DataTypes.V1.Request.FileList;
using SinusBotAPI.DataTypes.V1.Request.Instance;
using SinusBotAPI.DataTypes.V1.Request.Playback;
using SinusBotAPI.DataTypes.V1.Response.Instance;

namespace SinusBotAPI;

public interface ISinusBotClient
{
    /// <summary>
    /// Gets the default bot Id
    /// </summary>
    Task<string> GetBotId();
    
    /// <summary>
    /// Authenticates the api to the bot
    /// </summary>
    /// <param name="userName">SinusBot login username</param>
    /// <param name="password">SinusBot login password</param>
    Task Authenticate(string userName, string password);
    
    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task<CreateInstanceResponse> CreateInstance(CreateInstanceRequest createInstanceRequest);
    
    /// <summary>
    /// Deletes an instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task DeleteInstance(string uuid);
    
    /// <summary>
    /// Starts an stopped instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task StartInstance(string uuid);
    
    /// <summary>
    /// Restarts a running instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task RestartInstance(string uuid);
    
    /// <summary>
    /// Shuts down a running instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task ShutdownInstance(string uuid);
    
    /// <summary>
    /// Gets the status of a instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task<InstanceStatusResponse> GetInstanceStatus(string uuid);
    
    /// <summary>
    /// Updates the settings of a instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task UpdateSettings(UpdateSettingsRequest updateSettingsRequest);
    
    /// <summary>
    /// Gets a list of instances
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task<List<InstanceData>> GetInstances();
    
    /// <summary>
    /// Adds a url to the files list
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task AddFileListUrl(AddUrlRequest addUrlRequest);
    
    /// <summary>
    /// Creates a new folder
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task CreateFileListFolder(CreateFolderRequest createFolderRequest);
    
    /// <summary>
    /// Deletes a file
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task DeleteFile(string uuid);
    
    /// <summary>
    /// Gets all files on the bot
    /// </summary>
    /// <returns></returns>
    Task<List<FileData>> GetFiles();
    
    /// <summary>
    /// Updates a file
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task UpdateFile(UpdateFileRequest updateFileRequest);
    
    /// <summary>
    /// Decreases the playback volume of a instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task DecreaseVolume(string instanceUuid);
    
    /// <summary>
    /// Increases the playback volume of a instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task IncreaseVolume(string instanceUuid);
    
    /// <summary>
    /// Mutes or unmutes a instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task MuteUnmuteVolume(string instanceUuid, bool mute);
    
    /// <summary>
    /// Pauses the playback on a instance
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task PausePlayback(string instanceUuid);
    
    /// <summary>
    /// Starts the playback of a url
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task PlaybackUrl(string instanceUuid, string url);
    
    /// <summary>
    /// Starts the playback of a file in a playlist
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task PlaybackFileInPlaylist(string instanceUuid, string playListUuid, int index);
    
    /// <summary>
    /// Starts the playback of a file
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task PlaybackFile(string instanceUuid, string fileId);
    
    /// <summary>
    /// Text to speech
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task Say(TtsRequest ttsRequest);
    
    /// <summary>
    /// Seeks in the playback
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task PlaybackSeek(string instanceUuid, int value);
    
    /// <summary>
    /// Sets the playback volume of a instance to a value from 0 to 100
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task SetVolumePercent(string instanceUuid, int value);
    
    /// <summary>
    /// Stops the playback
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task StopPlayback(string instanceUuid);
    
    /// <summary>
    /// Gets the recently played files
    /// </summary>
    /// <remarks>Authentication required</remarks>
    Task<List<string>> GetRecentlyPlayedTracks(string instanceUuid);
}