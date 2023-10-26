namespace SinusBotAPI.DataTypes.V1.Request.FileList;

public class CreateFolderRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Parent { get; set; }
}