using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<Reason>))]
public record Reason : StringEnum<Reason>
{
    public static readonly Reason Market = new("market");

    public static readonly Reason Product = new("product");

    public static readonly Reason Explicit = new("explicit");

    private Reason(string value) : base(value)
    {
    }
}
