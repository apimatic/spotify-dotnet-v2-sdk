using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Type6>))]
public record Type6 : StringEnum<Type6>
{
    public static readonly Type6 Show = new("show");

    private Type6(string value) : base(value)
    {
    }
}
