using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record Track1
{
    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
