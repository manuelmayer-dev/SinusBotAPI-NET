namespace SinusBotAPI.DataTypes.V1.Response.General;

public class BotInfoResponse
{
    public BotData? Bot { get; set; }
    
    public SystemData? System { get; set; }
    
    public float? UsageMemory { get; set; }
}