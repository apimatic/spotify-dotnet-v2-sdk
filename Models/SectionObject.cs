using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record SectionObject
{
    [JsonPropertyName("start")]
    public decimal? Start { get; init; }

    [JsonPropertyName("duration")]
    public decimal? Duration { get; init; }

    [JsonPropertyName("confidence")]
    public decimal? Confidence { get; init; }

    [JsonPropertyName("loudness")]
    public decimal? Loudness { get; init; }

    [JsonPropertyName("tempo")]
    public decimal? Tempo { get; init; }

    [JsonPropertyName("tempo_confidence")]
    public decimal? TempoConfidence { get; init; }

    [JsonPropertyName("key")]
    public double? Key { get; init; }

    [JsonPropertyName("key_confidence")]
    public decimal? KeyConfidence { get; init; }

    [JsonPropertyName("mode")]
    public Mode? Mode { get; init; }

    [JsonPropertyName("mode_confidence")]
    public decimal? ModeConfidence { get; init; }

    [JsonPropertyName("time_signature")]
    public double? TimeSignature { get; init; }

    [JsonPropertyName("time_signature_confidence")]
    public decimal? TimeSignatureConfidence { get; init; }
}
