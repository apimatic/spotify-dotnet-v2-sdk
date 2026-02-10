using System.Text.Json;

namespace SpotifyWebApi.Core.Extensions;

public static class JsonSerializerExtensions
{
    extension(JsonSerializer)
    {
        public static bool TryDeserialize<T>(JsonElement element, JsonSerializerOptions options, out T result)
        {
            try
            {
                result = element.Deserialize<T>(options)!;
                return true;
            }
            catch (JsonException)
            {
                // expected: malformed JSON for this type
                result = default!;
                return false;
            }
            catch (NotSupportedException)
            {
                // expected: type not supported by STJ
                result = default!;
                return false;
            }
        }
    }
}