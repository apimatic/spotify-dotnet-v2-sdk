using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyTracks
{
    [JsonPropertyName("tracks")]
    public required IReadOnlyList<TrackObject> Tracks { get; init; }
}
