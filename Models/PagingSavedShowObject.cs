using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PagingSavedShowObject
{
    [JsonPropertyName("href")]
    public required string Href { get; init; }

    [JsonPropertyName("limit")]
    public required double Limit { get; init; }

    [JsonPropertyName("next")]
    public required string? Next { get; init; }

    [JsonPropertyName("offset")]
    public required double Offset { get; init; }

    [JsonPropertyName("previous")]
    public required string? Previous { get; init; }

    [JsonPropertyName("total")]
    public required double Total { get; init; }

    [JsonPropertyName("items")]
    public required IReadOnlyList<SavedShowObject> Items { get; init; }
}
