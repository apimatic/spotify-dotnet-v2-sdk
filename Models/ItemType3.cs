using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<ItemType3>))]
public record ItemType3 : StringEnum<ItemType3>
{
    public static readonly ItemType3 Artist = new("artist");

    public static readonly ItemType3 User = new("user");

    private ItemType3(string value) : base(value)
    {
    }
}
