using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type3>))]
public record Type3 : StringEnum<Type3>
{
    public static readonly Type3 Track = new("track");

    private Type3(string value) : base(value)
    {
    }
}
