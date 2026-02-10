using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MeFollowingRequest
{
    [JsonPropertyName("ids")]
    public required IReadOnlyList<string> Ids { get; init; }
}
