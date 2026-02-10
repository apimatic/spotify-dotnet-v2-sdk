using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record CursorPagingPlayHistoryObject
{
    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("limit")]
    public double? Limit { get; init; }

    [JsonPropertyName("next")]
    public string? Next { get; init; }

    [JsonPropertyName("cursors")]
    public CursorObject? Cursors { get; init; }

    [JsonPropertyName("total")]
    public double? Total { get; init; }

    [JsonPropertyName("items")]
    public IReadOnlyList<PlayHistoryObject>? Items { get; init; }
}
