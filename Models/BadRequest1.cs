using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record BadRequest1
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
