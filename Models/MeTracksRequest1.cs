using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MeTracksRequest1
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<string>? Ids { get; init; }
}
