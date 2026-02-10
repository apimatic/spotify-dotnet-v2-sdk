using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PlaylistsTracksRequest1
{
    [JsonPropertyName("uris")]
    public IReadOnlyList<string>? Uris { get; init; }

    [JsonPropertyName("range_start")]
    public double? RangeStart { get; init; }

    [JsonPropertyName("insert_before")]
    public double? InsertBefore { get; init; }

    [JsonPropertyName("range_length")]
    public double? RangeLength { get; init; }

    [JsonPropertyName("snapshot_id")]
    public string? SnapshotId { get; init; }
}
