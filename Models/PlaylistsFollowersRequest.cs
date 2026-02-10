using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PlaylistsFollowersRequest
{
    [JsonPropertyName("public")]
    public bool? Public { get; init; }
}
