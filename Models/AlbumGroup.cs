using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<AlbumGroup>))]
public record AlbumGroup : StringEnum<AlbumGroup>
{
    public static readonly AlbumGroup Album = new("album");

    public static readonly AlbumGroup Single = new("single");

    public static readonly AlbumGroup Compilation = new("compilation");

    public static readonly AlbumGroup AppearsOn = new("appears_on");

    private AlbumGroup(string value) : base(value)
    {
    }
}
