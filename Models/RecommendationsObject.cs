using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record RecommendationsObject
{
    [JsonPropertyName("seeds")]
    public required IReadOnlyList<RecommendationSeedObject> Seeds { get; init; }

    [JsonPropertyName("tracks")]
    public required IReadOnlyList<TrackObject> Tracks { get; init; }
}
