using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type4>))]
public record Type4 : StringEnum<Type4>
{
    public static readonly Type4 User = new("user");

    private Type4(string value) : base(value)
    {
    }
}
