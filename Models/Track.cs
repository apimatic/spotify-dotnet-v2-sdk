using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record Track
{
    [JsonPropertyName("num_samples")]
    public double? NumSamples { get; init; }

    [JsonPropertyName("duration")]
    public decimal? Duration { get; init; }

    [JsonPropertyName("sample_md5")]
    public string? SampleMd5 { get; init; }

    [JsonPropertyName("offset_seconds")]
    public double? OffsetSeconds { get; init; }

    [JsonPropertyName("window_seconds")]
    public double? WindowSeconds { get; init; }

    [JsonPropertyName("analysis_sample_rate")]
    public double? AnalysisSampleRate { get; init; }

    [JsonPropertyName("analysis_channels")]
    public double? AnalysisChannels { get; init; }

    [JsonPropertyName("end_of_fade_in")]
    public decimal? EndOfFadeIn { get; init; }

    [JsonPropertyName("start_of_fade_out")]
    public decimal? StartOfFadeOut { get; init; }

    [JsonPropertyName("loudness")]
    public decimal? Loudness { get; init; }

    [JsonPropertyName("tempo")]
    public decimal? Tempo { get; init; }

    [JsonPropertyName("tempo_confidence")]
    public decimal? TempoConfidence { get; init; }

    [JsonPropertyName("time_signature")]
    public double? TimeSignature { get; init; }

    [JsonPropertyName("time_signature_confidence")]
    public decimal? TimeSignatureConfidence { get; init; }

    [JsonPropertyName("key")]
    public double? Key { get; init; }

    [JsonPropertyName("key_confidence")]
    public decimal? KeyConfidence { get; init; }

    [JsonPropertyName("mode")]
    public double? Mode { get; init; }

    [JsonPropertyName("mode_confidence")]
    public decimal? ModeConfidence { get; init; }

    [JsonPropertyName("codestring")]
    public string? Codestring { get; init; }

    [JsonPropertyName("code_version")]
    public decimal? CodeVersion { get; init; }

    [JsonPropertyName("echoprintstring")]
    public string? Echoprintstring { get; init; }

    [JsonPropertyName("echoprint_version")]
    public decimal? EchoprintVersion { get; init; }

    [JsonPropertyName("synchstring")]
    public string? Synchstring { get; init; }

    [JsonPropertyName("synch_version")]
    public decimal? SynchVersion { get; init; }

    [JsonPropertyName("rhythmstring")]
    public string? Rhythmstring { get; init; }

    [JsonPropertyName("rhythm_version")]
    public decimal? RhythmVersion { get; init; }
}
