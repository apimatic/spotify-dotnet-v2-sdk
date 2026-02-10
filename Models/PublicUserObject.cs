using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PublicUserObject
{
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("external_urls")]
    public ExternalUrlObject? ExternalUrls { get; init; }

    [JsonPropertyName("followers")]
    public FollowersObject? Followers { get; init; }

    [JsonPropertyName("href")]
    public string? Href { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("images")]
    public IReadOnlyList<ImageObject>? Images { get; init; }

    [JsonPropertyName("type")]
    public Type4? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
