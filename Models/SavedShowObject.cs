using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Converters;

namespace SpotifyWebApi.Models;

public record SavedShowObject
{
    [JsonPropertyName("added_at")]
    [JsonConverter(typeof(Iso8601DateTimeConverter))]
    public DateTimeOffset? AddedAt { get; init; }

    [JsonPropertyName("show")]
    public ShowBase? Show { get; init; }
}
