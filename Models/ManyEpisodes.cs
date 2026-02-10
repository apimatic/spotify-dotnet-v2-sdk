using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyEpisodes
{
    [JsonPropertyName("episodes")]
    public required IReadOnlyList<EpisodeObject> Episodes { get; init; }
}
