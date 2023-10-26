using System.Text.Json.Serialization;
using SinusBotAPI.DataTypes.V1.Enums;

namespace SinusBotAPI.DataTypes.V1;

public class BotData
{
    public string? Id { get; set; }
    
    public string? Alias { get; set; }
    
    public string? SpaceUsed { get; set; }
    
    public int? LimitSpace { get; set; }
    
    public int? LimitFiles { get; set; }
    
    public int? LimitPlaylists { get; set; }
    
    public int? LimitInstances { get; set; }
    
    public int? LimitUsers { get; set; }
    
    public int? LimitDownloadRate { get; set; }
    
    public int? LimitDownloadSize { get; set; }
    
    public int? Locked { get; set; }
    
    public int? Deleted { get; set; }
    
    public int? DisallowDownload { get; set; }
    
    public int? DisallowStreaming { get; set; }
    
    public int? DownloadedBytes { get; set; }
    
    public int? StatHttpRequests { get; set; }
    
    public int? StatPlayCount { get; set; }
    
    public int? StatCommandCount { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public List<BackendType>? AllowedBackends { get; set; }
    
    public bool? DisallowRegistration { get; set; }
}
