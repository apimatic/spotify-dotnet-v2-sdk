using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyGenres
{
    [JsonPropertyName("genres")]
    public required IReadOnlyList<string> Genres { get; init; }
}
