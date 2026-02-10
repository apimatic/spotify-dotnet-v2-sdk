using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ContextObject
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("external_urls")]
    public ExternalUrlObject? ExternalUrls { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
