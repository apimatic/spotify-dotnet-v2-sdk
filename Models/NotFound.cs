using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record NotFound
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
