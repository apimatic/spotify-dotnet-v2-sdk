using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type8>))]
public record Type8 : StringEnum<Type8>
{
    public static readonly Type8 AudioFeatures = new("audio_features");

    private Type8(string value) : base(value)
    {
    }
}
