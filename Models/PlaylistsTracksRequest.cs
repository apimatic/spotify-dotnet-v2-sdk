using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PlaylistsTracksRequest
{
    [JsonPropertyName("uris")]
    public IReadOnlyList<string>? Uris { get; init; }

    [JsonPropertyName("position")]
    public double? Position { get; init; }
}
