using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MeEpisodesRequest1
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<string>? Ids { get; init; }
}
