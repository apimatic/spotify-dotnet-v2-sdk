namespace SpotifyWebApi.Core.Models;

public readonly record struct Param(
    string Key,
    object? Value,
    SerializationFormat SerializationFormat = SerializationFormat.Plain);