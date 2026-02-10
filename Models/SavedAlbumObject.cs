using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Converters;

namespace SpotifyWebApi.Models;

public record SavedAlbumObject
{
    [JsonPropertyName("added_at")]
    [JsonConverter(typeof(Iso8601DateTimeConverter))]
    public DateTimeOffset? AddedAt { get; init; }

    [JsonPropertyName("album")]
    public AlbumObject? Album { get; init; }
}
