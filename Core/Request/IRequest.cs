namespace SpotifyWebApi.Core.Request;

public interface IRequest
{
    HttpContent Get();
    
    bool CanRetry { get; }
}