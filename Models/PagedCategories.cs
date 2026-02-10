using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record PagedCategories
{
    [JsonPropertyName("categories")]
    public required Categories Categories { get; init; }
}
