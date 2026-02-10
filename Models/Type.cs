using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type>))]
public record Type : StringEnum<Type>
{
    public static readonly Type Artist = new("artist");

    private Type(string value) : base(value)
    {
    }
}
