using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Converters;

namespace SpotifyWebApi.Models;

public record PlaylistTrackObject
{
    [JsonPropertyName("added_at")]
    [JsonConverter(typeof(Iso8601DateTimeConverter))]
    public DateTimeOffset? AddedAt { get; init; }

    [JsonPropertyName("added_by")]
    public PlaylistUserObject? AddedBy { get; init; }

    [JsonPropertyName("is_local")]
    public bool? IsLocal { get; init; }

    [JsonPropertyName("track")]
    public object? Track { get; init; }
}
