using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Enum;

namespace SpotifyWebApi.Models;

[JsonConverter(typeof(StringEnumConverter<AlbumType>))]
public record AlbumType : StringEnum<AlbumType>
{
    public static readonly AlbumType Album = new("album");

    public static readonly AlbumType Single = new("single");

    public static readonly AlbumType Compilation = new("compilation");

    private AlbumType(string value) : base(value)
    {
    }
}
