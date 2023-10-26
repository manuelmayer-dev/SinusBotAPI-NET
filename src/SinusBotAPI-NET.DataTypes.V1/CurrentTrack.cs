namespace SinusBotAPI.DataTypes.V1;

public class CurrentTrack
{
    public int? V { get; set; }
    
    public string? Uuid { get; set; }
    
    public string? Parent { get; set; }
    
    public string? Type { get; set; }
    
    public string? Codec { get; set; }
    
    public long? Duration { get; set; }
    
    public long? Filesize { get; set; }
    
    public string? Filename { get; set; }
    
    public string? Title { get; set; }
    
    public string? Artist { get; set; }
    
    public bool? Ephemeral { get; set; }
    
    public bool? DeleteAfter { get; set; }
    
    public bool? Loop { get; set; }
    
    public bool? DisableReconnect { get; set; }
    
    public string? Thumbnail { get; set; }
    
    public string? RewrittenTo { get; set; }
    
    public string? SearchRef { get; set; }
    
    public string? Callback { get; set; }
    
    public string? Alias { get; set; }
}
