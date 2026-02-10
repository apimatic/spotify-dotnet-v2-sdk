using System.Globalization;
using System.Web;
using SpotifyWebApi.Core.Models;

namespace SpotifyWebApi.Core;

public class QueryParameterFactory
{
    private readonly IReadOnlyCollection<Param> _defaultQueryParams;

    public QueryParameterFactory(IReadOnlyCollection<Param> defaultQueryParams) =>
        _defaultQueryParams = defaultQueryParams;

    public string Serialize(IReadOnlyCollection<Param> queryParams)
    {
        var totalParams = _defaultQueryParams.Concat(queryParams);
        var parts = GenerateParts(totalParams);
        return string.Join("&", parts);
    }

    private static IEnumerable<string> GenerateParts(IEnumerable<Param> queryParams)
    {
        foreach (var queryParam in queryParams)
        {
            var flattened = ParameterFlattener.Flatten(queryParam);

            foreach (var f in flattened) yield return $"{Uri.EscapeDataString(f.Key)}={Uri.EscapeDataString(f.Value)}";
        }
    }
}

public static class QueryParamExtensions
{
    //public static T ParseQueryParam<T>(string url, string paramName)
    //{
    //    if (url.TryGetQueryParam<T>(paramName, out var value))
    //    {
    //        return value;
    //    }
    //    throw )
    //}
    public static bool TryGetQueryParam<T>(string url, string paramName, out T value)
    {
        value = default!;

        if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(paramName))
            return false;

        var uri = url.StartsWith("http", StringComparison.OrdinalIgnoreCase)
            ? new Uri(url)
            : new Uri("http://dummy" + url);

        var raw = HttpUtility.ParseQueryString(uri.Query)[paramName];
        if (raw is null)
            return false;

        return TryParsePrimitive(raw, out value);

    }

    private static bool TryParsePrimitive<T>(string raw, out T value)
    {
        value = default!;

        var type = typeof(T);

        if (type == typeof(string))
        {
            value = (T)(object)raw;
            return true;
        }

        if (type == typeof(int))
        {
            if (int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
            {
                value = (T)(object)result;
                return true;
            }
            return false;
        }

        if (type == typeof(long))
        {
            if (long.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
            {
                value = (T)(object)result;
                return true;
            }
            return false;
        }

        if (type == typeof(double))
        {
            if (double.TryParse(raw, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var result))
            {
                value = (T)(object)result;
                return true;
            }
            return false;
        }

        if (type == typeof(decimal))
        {
            if (decimal.TryParse(raw, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
            {
                value = (T)(object)result;
                return true;
            }
            return false;
        }

        if (type == typeof(bool))
        {
            if (bool.TryParse(raw, out var result))
            {
                value = (T)(object)result;
                return true;
            }
            return false;
        }

        if (type == typeof(Guid))
        {
            if (Guid.TryParse(raw, out var result))
            {
                value = (T)(object)result;
                return true;
            }
            return false;
        }

        // Unsupported type
        return false;
    }
}