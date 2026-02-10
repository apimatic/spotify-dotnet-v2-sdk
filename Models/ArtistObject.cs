using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ArtistObject
{
    [JsonPropertyName("external_urls")]
    public ExternalUrlObject? ExternalUrls { get; init; }

    [JsonPropertyName("followers")]
    public FollowersObject? Followers { get; init; }

    [JsonPropertyName("genres")]
    public IReadOnlyList<string>? Genres { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("images")]
    public IReadOnlyList<ImageObject>? Images { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("popularity")]
    public double? Popularity { get; init; }

    [JsonPropertyName("type")]
    public Type? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
