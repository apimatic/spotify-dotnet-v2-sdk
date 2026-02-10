using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record QueueObject
{
    [JsonPropertyName("currently_playing")]
    public object? CurrentlyPlaying { get; init; }

    [JsonPropertyName("queue")]
    public IReadOnlyList<object>? Queue { get; init; }
}
