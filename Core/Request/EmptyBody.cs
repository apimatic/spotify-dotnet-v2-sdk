namespace SpotifyWebApi.Core.Request;

public class EmptyBody : IRequest
{
    public static EmptyBody Instance { get; } =  new();
    public HttpContent Get() => new StringContent(string.Empty);
    
    public bool CanRetry => true;
}