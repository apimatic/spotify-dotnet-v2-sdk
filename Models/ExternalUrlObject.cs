using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ExternalUrlObject
{
    [JsonPropertyName("spotify")]
    public string? Spotify { get; init; }
}
