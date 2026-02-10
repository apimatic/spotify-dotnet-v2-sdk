using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ChapterBase
{
    [JsonPropertyName("audio_preview_url")]
    public required string? AudioPreviewUrl { get; init; }

    [JsonPropertyName("available_markets")]
    public IReadOnlyList<string>? AvailableMarkets { get; init; }

    [JsonPropertyName("chapter_number")]
    public required double ChapterNumber { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("html_description")]
    public required string HtmlDescription { get; init; }

    [JsonPropertyName("duration_ms")]
    public required double DurationMs { get; init; }

    [JsonPropertyName("explicit")]
    public required bool Explicit { get; init; }

    [JsonPropertyName("external_urls")]
    public required ExternalUrlObject ExternalUrls { get; init; }

    [JsonPropertyName("href")]
    public required string Href { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("images")]
    public required IReadOnlyList<ImageObject> Images { get; init; }

    [JsonPropertyName("is_playable")]
    public required bool IsPlayable { get; init; }

    [JsonPropertyName("languages")]
    public required IReadOnlyList<string> Languages { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("release_date")]
    public required string ReleaseDate { get; init; }

    [JsonPropertyName("release_date_precision")]
    public required ReleaseDatePrecision ReleaseDatePrecision { get; init; }

    [JsonPropertyName("resume_point")]
    public ResumePointObject? ResumePoint { get; init; }

    [JsonPropertyName("type")]
    public required Type5 Type { get; init; }

    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    [JsonPropertyName("restrictions")]
    public ChapterRestrictionObject? Restrictions { get; init; }
}
