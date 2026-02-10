using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MePlayerRequest
{
    [JsonPropertyName("device_ids")]
    public required IReadOnlyList<string> DeviceIds { get; init; }

    [JsonPropertyName("play")]
    public bool? Play { get; init; }
}
