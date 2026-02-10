using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record AuthorObject
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
