using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type5>))]
public record Type5 : StringEnum<Type5>
{
    public static readonly Type5 Episode = new("episode");

    private Type5(string value) : base(value)
    {
    }
}
