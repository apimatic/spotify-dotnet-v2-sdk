using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Converters;

namespace SpotifyWebApi.Models;

public record SavedAudiobookObject
{
    [JsonPropertyName("added_at")]
    [JsonConverter(typeof(Iso8601DateTimeConverter))]
    public DateTimeOffset? AddedAt { get; init; }

    [JsonPropertyName("audiobook")]
    public AudiobookObject? Audiobook { get; init; }
}
