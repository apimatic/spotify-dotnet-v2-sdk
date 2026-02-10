using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record SegmentObject
{
    [JsonPropertyName("start")]
    public decimal? Start { get; init; }

    [JsonPropertyName("duration")]
    public decimal? Duration { get; init; }

    [JsonPropertyName("confidence")]
    public decimal? Confidence { get; init; }

    [JsonPropertyName("loudness_start")]
    public decimal? LoudnessStart { get; init; }

    [JsonPropertyName("loudness_max")]
    public decimal? LoudnessMax { get; init; }

    [JsonPropertyName("loudness_max_time")]
    public decimal? LoudnessMaxTime { get; init; }

    [JsonPropertyName("loudness_end")]
    public decimal? LoudnessEnd { get; init; }

    [JsonPropertyName("pitches")]
    public IReadOnlyList<decimal>? Pitches { get; init; }

    [JsonPropertyName("timbre")]
    public IReadOnlyList<decimal>? Timbre { get; init; }
}
