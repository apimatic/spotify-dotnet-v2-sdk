using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record AudiobookBase
{
    [JsonPropertyName("authors")]
    public required IReadOnlyList<AuthorObject> Authors { get; init; }

    [JsonPropertyName("available_markets")]
    public required IReadOnlyList<string> AvailableMarkets { get; init; }

    [JsonPropertyName("copyrights")]
    public required IReadOnlyList<CopyrightObject> Copyrights { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("html_description")]
    public required string HtmlDescription { get; init; }

    [JsonPropertyName("edition")]
    public string? Edition { get; init; }

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

    [JsonPropertyName("languages")]
    public required IReadOnlyList<string> Languages { get; init; }

    [JsonPropertyName("media_type")]
    public required string MediaType { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("narrators")]
    public required IReadOnlyList<NarratorObject> Narrators { get; init; }

    [JsonPropertyName("publisher")]
    public required string Publisher { get; init; }

    [JsonPropertyName("type")]
    public required Type9 Type { get; init; }

    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    [JsonPropertyName("total_chapters")]
    public required double TotalChapters { get; init; }
}
