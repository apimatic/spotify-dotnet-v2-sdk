using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ChapterRestrictionObject
{
    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
