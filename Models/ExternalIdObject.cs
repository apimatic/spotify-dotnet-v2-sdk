using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ExternalIdObject
{
    [JsonPropertyName("isrc")]
    public string? Isrc { get; init; }

    [JsonPropertyName("ean")]
    public string? Ean { get; init; }

    [JsonPropertyName("upc")]
    public string? Upc { get; init; }
}
