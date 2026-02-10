using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record Unauthorized
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
