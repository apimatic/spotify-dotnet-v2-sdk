using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record AudioFeaturesObject
{
    [JsonPropertyName("acousticness")]
    public decimal? Acousticness { get; init; }

    [JsonPropertyName("analysis_url")]
    public string? AnalysisUrl { get; init; }

    [JsonPropertyName("danceability")]
    public decimal? Danceability { get; init; }

    [JsonPropertyName("duration_ms")]
    public double? DurationMs { get; init; }

    [JsonPropertyName("energy")]
    public decimal? Energy { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("instrumentalness")]
    public decimal? Instrumentalness { get; init; }

    [JsonPropertyName("key")]
    public double? Key { get; init; }

    [JsonPropertyName("liveness")]
    public decimal? Liveness { get; init; }

    [JsonPropertyName("loudness")]
    public decimal? Loudness { get; init; }

    [JsonPropertyName("mode")]
    public double? Mode { get; init; }

    [JsonPropertyName("speechiness")]
    public decimal? Speechiness { get; init; }

    [JsonPropertyName("tempo")]
    public decimal? Tempo { get; init; }

    [JsonPropertyName("time_signature")]
    public double? TimeSignature { get; init; }

    [JsonPropertyName("track_href")]
    public string? TrackHref { get; init; }

    [JsonPropertyName("type")]
    public Type8? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("valence")]
    public decimal? Valence { get; init; }
}
