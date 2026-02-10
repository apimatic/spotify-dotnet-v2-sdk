using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ErrorObject
{
    [JsonPropertyName("status")]
    public required double Status { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }
}
