using System.Text.Json.Serialization;

namespace SinusBotAPI.DataTypes.V1;

public class ConnectionStatus
{
    public int? Status { get; set; }
    
    public long? ConnectedTime { get; set; }
    
    public int? Latency { get; set; }
    
    public int? PacketLoss { get; set; }
    
    public int? PacketLossS2C { get; set; }
    
    public int? PacketLossC2S { get; set; }
    
    public long? BytesSent { get; set; }
    
    [JsonPropertyName("bytesRecv")]
    public long? BytesReceived { get; set; }
    
    public int? BandwidthSent { get; set; }
    
    [JsonPropertyName("bandwidthRecv")]
    public int? BandwidthReceived { get; set; }
    
    public string? ChannelId { get; set; }
}
