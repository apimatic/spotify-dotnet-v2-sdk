using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record SimplifiedTrackObject
{
    [JsonPropertyName("artists")]
    public IReadOnlyList<SimplifiedArtistObject>? Artists { get; init; }

    [JsonPropertyName("available_markets")]
    public IReadOnlyList<string>? AvailableMarkets { get; init; }

    [JsonPropertyName("disc_number")]
    public double? DiscNumber { get; init; }

    [JsonPropertyName("duration_ms")]
    public double? DurationMs { get; init; }

    [JsonPropertyName("explicit")]
    public bool? Explicit { get; init; }

    [JsonPropertyName("external_urls")]
    public ExternalUrlObject? ExternalUrls { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("is_playable")]
    public bool? IsPlayable { get; init; }

    [JsonPropertyName("linked_from")]
    public LinkedTrackObject? LinkedFrom { get; init; }

    [JsonPropertyName("restrictions")]
    public TrackRestrictionObject? Restrictions { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("preview_url")]
    public string? PreviewUrl { get; init; }

    [JsonPropertyName("track_number")]
    public double? TrackNumber { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }

    [JsonPropertyName("is_local")]
    public bool? IsLocal { get; init; }
}
