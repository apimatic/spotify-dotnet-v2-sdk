using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record BadRequest
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
