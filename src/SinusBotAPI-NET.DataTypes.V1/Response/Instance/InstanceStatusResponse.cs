using System.Text.Json.Serialization;

namespace SinusBotAPI.DataTypes.V1.Response.Instance;

public class InstanceStatusResponse
{
    public string? V { get; set; }

    public CurrentTrack? CurrentTrack { get; set; }

    public int? Position { get; set; }

    public bool? Running { get; set; }

    public bool? Playing { get; set; }

    public bool? Shuffle { get; set; }

    public bool? Repeat { get; set; }

    public int? Volume { get; set; }

    public bool? NeedsRestart { get; set; }

    public string? Playlist { get; set; }

    public int? PlaylistTrack { get; set; }

    public int? QueueLen { get; set; }

    public int? QueueVersion { get; set; }

    public int? Modes { get; set; }

    public int? Downloaded { get; set; }

    public string? ServerUid { get; set; }

    public int? Flags { get; set; }

    public int? Muted { get; set; }

    [JsonPropertyName("connStatus")]
    public ConnectionStatus? ConnectionStatus { get; set; }

    public int? StreamListeners { get; set; }

    public string? IdleTrack { get; set; }

    public string? StartupTrack { get; set; }
}