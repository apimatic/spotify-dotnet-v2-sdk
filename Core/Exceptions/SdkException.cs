namespace SpotifyWebApi.Core.Exceptions;

public class SdkException<TError> : Exception
{
    public required TError Error { get; init; }
}