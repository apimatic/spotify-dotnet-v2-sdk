using SpotifyWebApi.Core.Extensions;
using SpotifyWebApi.Core.Models;

namespace SpotifyWebApi.Core;

public static class ParameterFlattener
{
    public static IEnumerable<KeyValuePair<string, string>> Flatten(Param param)
    {
        var (key, value, format) = param;
        return Flatten(key, value, format)
            .Select(kv => new KeyValuePair<string, string>(kv.Key, kv.Value));
    }

    private static IEnumerable<(string Key, string Value)> Flatten(
        string key,
        object? value,
        SerializationFormat format)
    {
        // TODO: Shield handle null or empty or default value here;
        if (value == null) return [];

        var normalized = value.Normalize();
        return normalized switch
        {
            IDictionary<string, object?> dict => FlattenDict(key, dict, format),
            string str => [(key, str)],
            IEnumerable<object?> list => FlattenList(key, list, format),
            bool boolValue => [(key, boolValue.ToString().ToLowerInvariant())],
            _ => [(key, normalized?.ToString() ?? string.Empty)]
        };
    }

    // ------------------------------------------------------
    // Expression helpers (pure functions)
    // ------------------------------------------------------

    private static IEnumerable<(string, string)> FlattenDict(
        string key,
        IDictionary<string, object?> dict,
        SerializationFormat format)
        =>
            dict.SelectMany(kv =>
                Flatten($"{key}[{kv.Key}]", kv.Value, format)
            );

    private static IEnumerable<(string, string)> FlattenList(
        string key,
        IEnumerable<object?> list,
        SerializationFormat format)
        =>
            format switch
            {
                SerializationFormat.Plain => list.SelectMany(item => Flatten(key, item, format)),
                SerializationFormat.Indexed => Indexed(key, list),
                SerializationFormat.UnIndexed => UnIndexed(key, list),
                SerializationFormat.Csv => Yield(key, list, ","),
                SerializationFormat.Tsv => Yield(key, list, "\t"),
                SerializationFormat.Psv => Yield(key, list, "|"),
                _ => list.SelectMany(item => Flatten(key, item, format))
            };

    // ------------------------------------------------------
    // Specific list-format handlers (each is a pure expression)
    // ------------------------------------------------------
    private static IEnumerable<(string, string)> Indexed(string key, IEnumerable<object?> list)
        =>
            list.SelectMany((item, index) =>
                Flatten($"{key}[{index}]", item, SerializationFormat.Plain)
            );

    private static IEnumerable<(string, string)> UnIndexed(string key, IEnumerable<object?> list)
        =>
            list.SelectMany(item =>
                Flatten($"{key}[]", item, SerializationFormat.Plain)
            );

    private static IEnumerable<(string, string)> Yield(string key, IEnumerable<object?> list, string sep) =>
        [(key, string.Join(sep, list.Select(v => v?.ToString() ?? "")))];
}