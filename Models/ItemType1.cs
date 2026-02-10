using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<ItemType1>))]
public record ItemType1 : StringEnum<ItemType1>
{
    public static readonly ItemType1 Artist = new("artist");

    private ItemType1(string value) : base(value)
    {
    }
}
