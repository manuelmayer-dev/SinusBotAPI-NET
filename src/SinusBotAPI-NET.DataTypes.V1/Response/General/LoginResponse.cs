namespace SinusBotAPI.DataTypes.V1.Response.General;

public class LoginResponse : BaseSuccessResponse
{
    public string? Token { get; set; }
    
    public string? BotId { get; set; }
}