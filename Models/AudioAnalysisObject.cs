using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record AudioAnalysisObject
{
    [JsonPropertyName("meta")]
    public Meta? Meta { get; init; }

    [JsonPropertyName("track")]
    public Track? Track { get; init; }

    [JsonPropertyName("bars")]
    public IReadOnlyList<TimeIntervalObject>? Bars { get; init; }

    [JsonPropertyName("beats")]
    public IReadOnlyList<TimeIntervalObject>? Beats { get; init; }

    [JsonPropertyName("sections")]
    public IReadOnlyList<SectionObject>? Sections { get; init; }

    [JsonPropertyName("segments")]
    public IReadOnlyList<SegmentObject>? Segments { get; init; }

    [JsonPropertyName("tatums")]
    public IReadOnlyList<TimeIntervalObject>? Tatums { get; init; }
}
