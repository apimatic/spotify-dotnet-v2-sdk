using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManySimplifiedShows
{
    [JsonPropertyName("shows")]
    public required IReadOnlyList<ShowBase> Shows { get; init; }
}
