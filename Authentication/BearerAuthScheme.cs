using System.Net.Http.Headers;
using SpotifyWebApi.Core.Authentication;

namespace SpotifyWebApi.Authentication;

public sealed class BearerAuthScheme : IAuthScheme
{
    private readonly Func<string> _factory;

    public BearerAuthScheme(string token)
    {
        _factory = () => token;
    }

    // This supports lazy evaluation of credentials
    public BearerAuthScheme(Func<string> factory)
    {
        _factory = factory;
    }

    public ValueTask Apply(HttpRequestMessage request, CancellationToken ct)
    {
        var token = _factory();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return default;
    }
}