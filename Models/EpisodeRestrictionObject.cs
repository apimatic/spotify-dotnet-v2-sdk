using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record EpisodeRestrictionObject
{
    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
