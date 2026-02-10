using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyArtists
{
    [JsonPropertyName("artists")]
    public required IReadOnlyList<ArtistObject> Artists { get; init; }
}
