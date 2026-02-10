using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record Meta
{
    [JsonPropertyName("analyzer_version")]
    public string? AnalyzerVersion { get; init; }

    [JsonPropertyName("platform")]
    public string? Platform { get; init; }

    [JsonPropertyName("detailed_status")]
    public string? DetailedStatus { get; init; }

    [JsonPropertyName("status_code")]
    public double? StatusCode { get; init; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    [JsonPropertyName("analysis_time")]
    public decimal? AnalysisTime { get; init; }

    [JsonPropertyName("input_process")]
    public string? InputProcess { get; init; }
}
