using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<IncludeExternal>))]
public record IncludeExternal : StringEnum<IncludeExternal>
{
    public static readonly IncludeExternal Audio = new("audio");

    private IncludeExternal(string value) : base(value)
    {
    }
}
