namespace SpotifyWebApi.Core.Response;

public class ScalarResponse<TResponse> : IResponse<TResponse>
{
    private readonly Func<string, TResponse?> _map;

    public ScalarResponse(Func<string, TResponse?> map) => _map = map;

    public async Task<TResponse?> Map(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken)
    {
        // TODO: Add cancellation token with conditional compilation
        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        return _map(responseBody);
    }
}

public static class ScalarResponse
{
    public static ScalarResponse<TResponse> Create<TResponse>(Func<string, TResponse?> map) => new(map);
}