namespace SinusBotAPI.DataTypes.V1;

public class FileData
{
    public int? V { get; set; }

    public string? Uuid { get; set; }
    
    public string? Parent { get; set; }
    
    public string? Type { get; set; }
    
    public string? MimeType { get; set; }
    
    public string? Title { get; set; }
    
    public string? Artist { get; set; }
    
    public string? TempTitle { get; set; }
    
    public string? TempArtist { get; set; }
    
    public string? Album { get; set; }
    
    public string? AlbumArtist { get; set; }
    
    public int? Track { get; set; }
    
    public int? TotalTracks { get; set; }
    
    public string? Copyright { get; set; }
    
    public string? Genre { get; set; }
    
    public string? Thumbnail { get; set; }
    
    public string? Codec { get; set; }
    
    public int? Duration { get; set; }
    
    public int? Bitrate { get; set; }
    
    public int? Channels { get; set; }
    
    public int? Samplerate { get; set; }
    
    public int? Filesize { get; set; }
    
    public bool? Ephemeral { get; set; }
    
    public bool? DeleteAfter { get; set; }
    
    public bool? Loop { get; set; }
    
    public bool? DisableReconnect { get; set; }
    
    public string? Filename { get; set; }
    
    public string? RewrittenTo { get; set; }
    
    public string? SearchRef { get; set; }
    
    public string? Callback { get; set; }
    
    public string? Alias { get; set; }
}