namespace SinusBotAPI.DataTypes.V1.Request.Playback;

public class TtsRequest
{
    public string InstanceId { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public string? Locale { get; set; }
}