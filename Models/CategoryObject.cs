using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record CategoryObject
{
    [JsonPropertyName("href")]
    public required string Href { get; init; }

    [JsonPropertyName("icons")]
    public required IReadOnlyList<ImageObject> Icons { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
