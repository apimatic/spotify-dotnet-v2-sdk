using System.Globalization;

namespace SpotifyWebApi.Core.Extensions;

public static class DateTimeOffsetExtensions
{
    // Use the "r" standard format specifier (RFC1123 pattern).
    // DateTimeStyles.AssumeUniversal | AdjustToUniversal ensures parsed times are treated as UTC.
    private const string Rfc1123Format = "r";
    private const DateTimeStyles Styles = DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal;

    extension(DateTimeOffset)
    {
        public static DateTimeOffset? FromRfc1123(string dateString) =>
            DateTimeOffset.TryParseExact(dateString, Rfc1123Format, CultureInfo.InvariantCulture, Styles,
                out var dto)
                ? dto
                : null;

        public static DateTimeOffset? FromUnixTimeStamp(string dateString)
        {
            var seconds = long.Parse(dateString, CultureInfo.InvariantCulture);
            return DateTimeOffset.FromUnixTimeSeconds(seconds);
        }
    }

    extension(DateTimeOffset dateTimeOffset)
    {
        public string ToRfc1123() =>
            dateTimeOffset.ToUniversalTime().ToString(Rfc1123Format, CultureInfo.InvariantCulture);
    }
}