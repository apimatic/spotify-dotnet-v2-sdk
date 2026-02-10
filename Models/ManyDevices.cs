using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyDevices
{
    [JsonPropertyName("devices")]
    public required IReadOnlyList<DeviceObject> Devices { get; init; }
}
