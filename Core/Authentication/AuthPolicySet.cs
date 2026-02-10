namespace SpotifyWebApi.Core.Authentication;

/// <summary>
/// Represents a set of policies that must all succeed (AND logic)
/// </summary>
public sealed class AuthSchemeSet : IAuthScheme
{
    private readonly IReadOnlyList<IAuthScheme> _policies;

    public AuthSchemeSet(params IAuthScheme[] policies)
    {
        _policies = policies ?? throw new ArgumentNullException(nameof(policies));
    }

    public async ValueTask Apply(HttpRequestMessage request, CancellationToken ct)
    {
        foreach (var policy in _policies)
            await policy.Apply(request, ct);
    }
}