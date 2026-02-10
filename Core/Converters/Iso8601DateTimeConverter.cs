using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotifyWebApi.Core.Converters;

public class Iso8601DateTimeConverter : JsonConverter<DateTimeOffset>
{
// The "O" format specifier produces the 'Z' suffix when the Kind is Utc
    private const string DateTimeFormat = "O";

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetDateTimeOffset();

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToUniversalTime().ToString(DateTimeFormat, CultureInfo.InvariantCulture));
    }
}