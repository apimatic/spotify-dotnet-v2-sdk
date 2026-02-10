using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record NotFound1
{
    [JsonPropertyName("error")]
    public required ErrorObject Error { get; init; }
}
