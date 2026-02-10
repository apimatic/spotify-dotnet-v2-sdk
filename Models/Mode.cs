using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(IntEnumConverter<Mode>))]
public record Mode : IntEnum<Mode>
{
    public static readonly Mode __1 = new(-1);

    public static readonly Mode _0 = new(0);

    public static readonly Mode _1 = new(1);

    private Mode(int value) : base(value)
    {
    }
}
