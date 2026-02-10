using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ResumePointObject
{
    [JsonPropertyName("fully_played")]
    public bool? FullyPlayed { get; init; }

    [JsonPropertyName("resume_position_ms")]
    public double? ResumePositionMs { get; init; }
}
