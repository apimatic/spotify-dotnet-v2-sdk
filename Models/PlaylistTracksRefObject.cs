using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PlaylistTracksRefObject
{
    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("total")]
    public double? Total { get; init; }
}
