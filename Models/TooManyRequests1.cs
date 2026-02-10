using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record TooManyRequests1
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
