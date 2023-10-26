using System.Text.Json.Serialization;
using SinusBotAPI.DataTypes.V1.Enums;

namespace SinusBotAPI.DataTypes.V1.Request.Instance;

public class CreateInstanceRequest
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BackendType Backend { get; set; }

    public string Nick { get; set; } = string.Empty;
}