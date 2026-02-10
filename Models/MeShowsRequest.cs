using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MeShowsRequest
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<string>? Ids { get; init; }
}
