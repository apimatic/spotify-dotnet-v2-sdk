using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record ExplicitContentSettingsObject
{
    [JsonPropertyName("filter_enabled")]
    public bool? FilterEnabled { get; init; }

    [JsonPropertyName("filter_locked")]
    public bool? FilterLocked { get; init; }
}
