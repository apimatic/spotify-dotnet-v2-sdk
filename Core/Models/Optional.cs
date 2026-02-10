using System.Diagnostics;

namespace SpotifyWebApi.Core.Models;

[DebuggerDisplay("HasValue = {_hasValue}, Value = {_value}")]
internal readonly record struct Optional<TValue>
{
    private readonly bool _hasValue;
    private readonly TValue? _value;

    private Optional(TValue? value, bool hasValue)
    {
        _value = value;
        _hasValue = hasValue;
    }

    public static Optional<TValue> Some(TValue value) => new(value, true);

    public bool TryGetValue(out TValue value)
    {
        value = _value ?? default!;
        return _hasValue;
    }
}