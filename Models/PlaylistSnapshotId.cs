using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PlaylistSnapshotId
{
    [JsonPropertyName("snapshot_id")]
    public string? SnapshotId { get; init; }
}
