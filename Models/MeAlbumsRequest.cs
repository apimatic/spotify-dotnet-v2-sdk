using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record MeAlbumsRequest
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<string>? Ids { get; init; }
}
