using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record UsersPlaylistsRequest
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("public")]
    public bool? Public { get; init; }

    [JsonPropertyName("collaborative")]
    public bool? Collaborative { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
