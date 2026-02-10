using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record TrackRestrictionObject
{
    [JsonPropertyName("reason")]
    public string? Reason { get; init; }
}
