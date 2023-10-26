using System.Text.Json.Serialization;
using SinusBotAPI.DataTypes.V1.Enums;

namespace SinusBotAPI.DataTypes.V1;

public class InstanceData
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BackendType Backend { get; set; }

    public string? Uuid { get; set; }

    public string? Name { get; set; }

    public string? Nick { get; set; }

    public bool? Running { get; set; }

    public bool? Playing { get; set; }

    public bool? MainInstance { get; set; }

    public string? LicenseId { get; set; }

    public string? ServerHost { get; set; }

    public int? ServerPort { get; set; }
}