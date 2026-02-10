using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record CurrentlyPlayingContextObject
{
    [JsonPropertyName("device")]
    public DeviceObject? Device { get; init; }

    [JsonPropertyName("repeat_state")]
    public string? RepeatState { get; init; }

    [JsonPropertyName("shuffle_state")]
    public bool? ShuffleState { get; init; }

    [JsonPropertyName("context")]
    public ContextObject? Context { get; init; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    [JsonPropertyName("progress_ms")]
    public double? ProgressMs { get; init; }

    [JsonPropertyName("is_playing")]
    public bool? IsPlaying { get; init; }

    [JsonPropertyName("item")]
    public object? Item { get; init; }

    [JsonPropertyName("currently_playing_type")]
    public string? CurrentlyPlayingType { get; init; }

    [JsonPropertyName("actions")]
    public DisallowsObject? Actions { get; init; }
}
