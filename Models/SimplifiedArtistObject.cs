using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record SimplifiedArtistObject
{
    [JsonPropertyName("external_urls")]
    public ExternalUrlObject? ExternalUrls { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public Type? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
