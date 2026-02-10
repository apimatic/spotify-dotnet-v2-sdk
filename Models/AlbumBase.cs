using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record AlbumBase
{
    [JsonPropertyName("album_type")]
    public required AlbumType AlbumType { get; init; }

    [JsonPropertyName("total_tracks")]
    public required double TotalTracks { get; init; }

    [JsonPropertyName("available_markets")]
    public required IReadOnlyList<string> AvailableMarkets { get; init; }

    [JsonPropertyName("external_urls")]
    public required ExternalUrlObject ExternalUrls { get; init; }

    [JsonPropertyName("href")]
    public required string Href { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("images")]
    public required IReadOnlyList<ImageObject> Images { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("release_date")]
    public required string ReleaseDate { get; init; }

    [JsonPropertyName("release_date_precision")]
    public required ReleaseDatePrecision ReleaseDatePrecision { get; init; }

    [JsonPropertyName("restrictions")]
    public AlbumRestrictionObject? Restrictions { get; init; }

    [JsonPropertyName("type")]
    public required Type2 Type { get; init; }

    [JsonPropertyName("uri")]
    public required string Uri { get; init; }
}
