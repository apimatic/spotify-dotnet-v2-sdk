using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<ReleaseDatePrecision>))]
public record ReleaseDatePrecision : StringEnum<ReleaseDatePrecision>
{
    public static readonly ReleaseDatePrecision Year = new("year");

    public static readonly ReleaseDatePrecision Month = new("month");

    public static readonly ReleaseDatePrecision Day = new("day");

    private ReleaseDatePrecision(string value) : base(value)
    {
    }
}
