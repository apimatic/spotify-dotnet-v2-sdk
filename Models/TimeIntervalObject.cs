using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record TimeIntervalObject
{
    [JsonPropertyName("start")]
    public decimal? Start { get; init; }

    [JsonPropertyName("duration")]
    public decimal? Duration { get; init; }

    [JsonPropertyName("confidence")]
    public decimal? Confidence { get; init; }
}
