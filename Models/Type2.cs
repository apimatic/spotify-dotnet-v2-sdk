using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type2>))]
public record Type2 : StringEnum<Type2>
{
    public static readonly Type2 Album = new("album");

    private Type2(string value) : base(value)
    {
    }
}
