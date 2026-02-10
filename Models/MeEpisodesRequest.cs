using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MeEpisodesRequest
{
    [JsonPropertyName("ids")]
    public required IReadOnlyList<string> Ids { get; init; }
}
