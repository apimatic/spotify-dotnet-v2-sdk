using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record NarratorObject
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
