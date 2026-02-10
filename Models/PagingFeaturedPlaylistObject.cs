using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PagingFeaturedPlaylistObject
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("playlists")]
    public PagingPlaylistObject? Playlists { get; init; }
}
