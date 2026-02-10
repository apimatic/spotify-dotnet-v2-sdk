namespace SpotifyWebApi.Core.Response;

public interface IResponse<TResponse>
{
    // TODO: Add support for stream response
    Task<TResponse?> Map(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken);
}