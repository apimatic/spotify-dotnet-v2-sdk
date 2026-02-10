using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyAudiobooks
{
    [JsonPropertyName("audiobooks")]
    public required IReadOnlyList<AudiobookObject> Audiobooks { get; init; }
}
