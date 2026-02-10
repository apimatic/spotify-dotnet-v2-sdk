using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyAlbums
{
    [JsonPropertyName("albums")]
    public required IReadOnlyList<AlbumObject> Albums { get; init; }
}
