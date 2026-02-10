using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyChapters
{
    [JsonPropertyName("chapters")]
    public required IReadOnlyList<ChapterObject> Chapters { get; init; }
}
