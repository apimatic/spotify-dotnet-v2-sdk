using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<ItemType>))]
public record ItemType : StringEnum<ItemType>
{
    public static readonly ItemType Album = new("album");

    public static readonly ItemType Artist = new("artist");

    public static readonly ItemType Playlist = new("playlist");

    public static readonly ItemType Track = new("track");

    public static readonly ItemType Show = new("show");

    public static readonly ItemType Episode = new("episode");

    public static readonly ItemType Audiobook = new("audiobook");

    private ItemType(string value) : base(value)
    {
    }
}
