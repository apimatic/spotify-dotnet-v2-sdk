using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PrivateUserObject
{
    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("explicit_content")]
    public ExplicitContentSettingsObject? ExplicitContent { get; init; }

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

    [JsonPropertyName("product")]
    public string? Product { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
}
