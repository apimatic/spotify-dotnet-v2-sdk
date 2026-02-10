using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record CursorPagedArtists
{
    [JsonPropertyName("artists")]
    public required CursorPagingSimplifiedArtistObject Artists { get; init; }
}
