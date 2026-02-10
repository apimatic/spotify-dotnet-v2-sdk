using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type9>))]
public record Type9 : StringEnum<Type9>
{
    public static readonly Type9 Audiobook = new("audiobook");

    private Type9(string value) : base(value)
    {
    }
}
