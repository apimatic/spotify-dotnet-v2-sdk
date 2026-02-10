using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Converters;

namespace SpotifyWebApi.Models;

public record SavedEpisodeObject
{
    [JsonPropertyName("added_at")]
    [JsonConverter(typeof(Iso8601DateTimeConverter))]
    public DateTimeOffset? AddedAt { get; init; }

    [JsonPropertyName("episode")]
    public EpisodeObject? Episode { get; init; }
}
