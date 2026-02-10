using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PagedAlbums
{
    [JsonPropertyName("albums")]
    public required PagingSimplifiedAlbumObject Albums { get; init; }
}
