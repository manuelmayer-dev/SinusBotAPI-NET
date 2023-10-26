namespace SinusBotAPI.DataTypes.V1.Request.FileList;

public class UpdateFileRequest
{
    public string Id { get; set; } = string.Empty;

    public string? Title { get; set; }

    public string? Artist { get; set; }

    public string? Album { get; set; }

    public string? Parent { get; set; }
}