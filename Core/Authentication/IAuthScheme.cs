namespace SpotifyWebApi.Core.Authentication;


public interface IAuthScheme
{
    ValueTask Apply(HttpRequestMessage request, CancellationToken ct);
}

public static class AuthSchemeExtensions
{
    extension(IEnumerable<IAuthScheme> authPolicies)
    {
        public async ValueTask Apply(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            foreach (var authPolicy in authPolicies)
            {
                await authPolicy.Apply(httpRequest, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}