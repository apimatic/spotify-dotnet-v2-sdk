using System.Text.Json;
using System.Text.Json.Serialization;
using SpotifyWebApi.Core.Extensions;

namespace SpotifyWebApi.Core.Converters;

public sealed class Rfc1123DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Expect a JSON string token
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException(
                $"Unexpected token parsing DateTimeOffset. Expected String, got {reader.TokenType}.");

        var str = reader.GetString();
        if (str == null || string.IsNullOrWhiteSpace(str))
            throw new JsonException("Expected non-empty RFC1123 date string.");

        var dto = DateTimeOffset.FromRfc1123(str);
        if (dto.HasValue)
            // Ensure we return UTC-normalized DateTimeOffset
            return dto.Value.ToUniversalTime();

        // If parse failed, throw JsonException (consistent with System.Text.Json behavior)
        throw new JsonException($"Invalid RFC1123 date format: '{str}'");
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        // Normalize to UTC and write in RFC1123/GMT form
        var formatted = value.ToRfc1123();
        writer.WriteStringValue(formatted);
    }
}