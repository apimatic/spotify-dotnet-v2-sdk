using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record RecommendationSeedObject
{
    [JsonPropertyName("afterFilteringSize")]
    public double? AfterFilteringSize { get; init; }

    [JsonPropertyName("afterRelinkingSize")]
    public double? AfterRelinkingSize { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("initialPoolSize")]
    public double? InitialPoolSize { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
