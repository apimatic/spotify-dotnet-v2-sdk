using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MePlayerPlayRequest
{
    [JsonPropertyName("context_uri")]
    public string? ContextUri { get; init; }

    [JsonPropertyName("uris")]
    public IReadOnlyList<string>? Uris { get; init; }

    [JsonPropertyName("offset")]
    public object? Offset { get; init; }

    [JsonPropertyName("position_ms")]
    public double? PositionMs { get; init; }
}
