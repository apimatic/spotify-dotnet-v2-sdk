using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record Markets
{
    [JsonPropertyName("markets")]
    public IReadOnlyList<string>? MarketList { get; init; }
}
