using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record SearchItems
{
    [JsonPropertyName("tracks")]
    public PagingTrackObject? Tracks { get; init; }

    [JsonPropertyName("artists")]
    public PagingArtistObject? Artists { get; init; }

    [JsonPropertyName("albums")]
    public PagingSimplifiedAlbumObject? Albums { get; init; }

    [JsonPropertyName("playlists")]
    public PagingPlaylistObject? Playlists { get; init; }

    [JsonPropertyName("shows")]
    public PagingSimplifiedShowObject? Shows { get; init; }

    [JsonPropertyName("episodes")]
    public PagingSimplifiedEpisodeObject? Episodes { get; init; }

    [JsonPropertyName("audiobooks")]
    public PagingSimplifiedAudiobookObject? Audiobooks { get; init; }
}
