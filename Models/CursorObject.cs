using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record CursorObject
{
    [JsonPropertyName("after")]
    public string? After { get; init; }

    [JsonPropertyName("before")]
    public string? Before { get; init; }
}
