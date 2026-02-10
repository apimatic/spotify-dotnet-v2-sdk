using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Converters;

namespace SpotifyWebApi.Models;

public record PlayHistoryObject
{
    [JsonPropertyName("track")]
    public TrackObject? Track { get; init; }

    [JsonPropertyName("played_at")]
    [JsonConverter(typeof(Iso8601DateTimeConverter))]
    public DateTimeOffset? PlayedAt { get; init; }

    [JsonPropertyName("context")]
    public ContextObject? Context { get; init; }
}
