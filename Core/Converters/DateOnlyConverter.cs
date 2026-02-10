using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotifyWebApi.Core.Converters;

public class DateOnlyConverter : JsonConverter<DateTimeOffset>
{
    private const string Format = "yyyy-MM-dd";

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dt = DateTimeOffset.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture,
            DateTimeStyles.None);
        return new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, TimeSpan.Zero);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        var dateOnly = new DateTime(value.Year, value.Month, value.Day);
        writer.WriteStringValue(dateOnly.ToString(Format, CultureInfo.InvariantCulture));
    }
}