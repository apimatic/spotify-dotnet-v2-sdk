using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ShowBase
{
    [JsonPropertyName("available_markets")]
    public required IReadOnlyList<string> AvailableMarkets { get; init; }

    [JsonPropertyName("copyrights")]
    public required IReadOnlyList<CopyrightObject> Copyrights { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("html_description")]
    public required string HtmlDescription { get; init; }

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

    [JsonPropertyName("is_externally_hosted")]
    public required bool IsExternallyHosted { get; init; }

    [JsonPropertyName("languages")]
    public required IReadOnlyList<string> Languages { get; init; }

    [JsonPropertyName("media_type")]
    public required string MediaType { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("publisher")]
    public required string Publisher { get; init; }

    [JsonPropertyName("type")]
    public required Type6 Type { get; init; }

    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    [JsonPropertyName("total_episodes")]
    public required double TotalEpisodes { get; init; }
}
