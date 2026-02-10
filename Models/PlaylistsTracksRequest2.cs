using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PlaylistsTracksRequest2
{
    [JsonPropertyName("tracks")]
    public required IReadOnlyList<Track1> Tracks { get; init; }

    [JsonPropertyName("snapshot_id")]
    public string? SnapshotId { get; init; }
}
