namespace SinusBotAPI.DataTypes.V1.Request.General;

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string BotId { get; set; } = string.Empty;
}