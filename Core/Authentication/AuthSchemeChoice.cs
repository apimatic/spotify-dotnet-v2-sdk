namespace SpotifyWebApi.Core.Authentication;

/// <summary>
/// Represents multiple alternative policy sets (OR logic)
/// </summary>
public sealed class AuthSchemeChoice : IAuthScheme
{
    private readonly IReadOnlyList<IAuthScheme> _alternatives;

    public AuthSchemeChoice(params IAuthScheme[] alternatives)
    {
        if (alternatives == null || alternatives.Length == 0)
            throw new ArgumentException("Must provide at least one alternative");
        _alternatives = alternatives;
    }

    public async ValueTask Apply(HttpRequestMessage request, CancellationToken ct)
    {
        Exception? lastEx = null;

        foreach (var alternative in _alternatives)
        {
            try
            {
                await alternative.Apply(request, ct);
                return; // Success: OR satisfied
            }
            catch (Exception ex)
            {
                lastEx = ex; // try next alternative
            }
        }

        // If none succeed, fail
        throw new InvalidOperationException(
            "No authentication scheme succeeded in OR policy",
            lastEx
        );
    }
}