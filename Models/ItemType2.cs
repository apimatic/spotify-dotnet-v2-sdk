using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<ItemType2>))]
public record ItemType2 : StringEnum<ItemType2>
{
    public static readonly ItemType2 Artist = new("artist");

    public static readonly ItemType2 User = new("user");

    private ItemType2(string value) : base(value)
    {
    }
}
