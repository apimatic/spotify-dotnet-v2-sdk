using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ManyAudioFeatures
{
    [JsonPropertyName("audio_features")]
    public required IReadOnlyList<AudioFeaturesObject> AudioFeatures { get; init; }
}
