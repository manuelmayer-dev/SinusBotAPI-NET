namespace SinusBotAPI.DataTypes.V1.Request.FileList;

public class AddUrlRequest
{
    public string Url { get; set; } = string.Empty;

    public string? Title { get; set; }

    public string? Parent { get; set; }
}