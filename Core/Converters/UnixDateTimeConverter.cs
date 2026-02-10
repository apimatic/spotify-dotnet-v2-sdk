using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotifyWebApi.Core.Converters;

public sealed class UnixDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var seconds = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(seconds);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        var unixTime = value.ToUniversalTime().ToUnixTimeSeconds();
        writer.WriteNumberValue(unixTime);
    }
}