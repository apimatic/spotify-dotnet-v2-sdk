using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record CopyrightObject
{
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }
}
