using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record AlbumRestrictionObject
{
    [JsonPropertyName("reason")]
    public Reason? Reason { get; init; }
}
