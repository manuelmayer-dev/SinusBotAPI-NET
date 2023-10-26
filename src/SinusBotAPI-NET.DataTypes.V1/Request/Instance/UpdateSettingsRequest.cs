namespace SinusBotAPI.DataTypes.V1.Request.Instance;

public class UpdateSettingsRequest
{
    public string InstanceId { get; set; } = string.Empty;
    
    public string Nick { get; set; } = string.Empty;
    
    public string? ServerHost { get; set; }
    
    public int? ServerPort { get; set; }
    
    public string? ServerPassword { get; set; }
    
    public string? ChannelName { get; set; }
    
    public string? ChannelPassword { get; set; }
    
    public bool? UpdateDescription { get; set; }
    
    public bool? Announce { get; set; }
    
    public string? AnnounceString { get; set; }
    
    public string? Identity { get; set; }
    
    public bool? EnableDucking { get; set; }
    
    public double? DuckingVolume { get; set; }
    
    public bool? ChannelCommander { get; set; }
    
    public bool? StickToChannel { get; set; }
    
    public string? TtsExternalUrl { get; set; }
    
    public string? TtsDefaultLocale { get; set; }
    
    public bool? IgnoreChatServer { get; set; }
    
    public bool? IgnoreChatPrivate { get; set; }
    
    public bool? IgnoreChatChannel { get; set; }
    
    public string? IdleTrack { get; set; }
    
    public string? StartupTrack { get; set; }
}