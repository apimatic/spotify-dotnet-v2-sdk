namespace SpotifyWebApi.Core.Response;

public class NullableScalarResponse<TResponse> : IResponse<TResponse>
{
    private readonly Func<string, TResponse?> _map;

    public NullableScalarResponse(Func<string, TResponse?> map) => _map = map;

    public async Task<TResponse?> Map(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken)
    {
        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        return _map(responseBody);
    }
}

public static class NullableScalarResponse
{
    public static ScalarResponse<TResponse> Create<TResponse>(Func<string, TResponse?> map) => new(map);
}