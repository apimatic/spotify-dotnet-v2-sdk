using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ImageObject
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("height")]
    public required double? Height { get; init; }

    [JsonPropertyName("width")]
    public required double? Width { get; init; }
}
