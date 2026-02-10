using System.Text.Json.Serialization;

namespace SpotifyWebApi.Models;

public record DeviceObject
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("is_active")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("is_private_session")]
    public bool? IsPrivateSession { get; init; }

    [JsonPropertyName("is_restricted")]
    public bool? IsRestricted { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("volume_percent")]
    public double? VolumePercent { get; init; }

    [JsonPropertyName("supports_volume")]
    public bool? SupportsVolume { get; init; }
}
