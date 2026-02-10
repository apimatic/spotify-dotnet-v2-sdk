using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record Forbidden
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
