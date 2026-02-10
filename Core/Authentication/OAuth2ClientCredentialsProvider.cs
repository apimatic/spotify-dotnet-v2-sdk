using System.Text.Json.Serialization;
using SpotifyWebApi.Core.ErrorResponse;
using SpotifyWebApi.Core.Models;
using SpotifyWebApi.Core.Request;
using SpotifyWebApi.Core.Response;

namespace SpotifyWebApi.Core.Authentication;

public sealed class OAuth2AccessToken
{
    public required string AccessToken { get; init; }
    public required DateTimeOffset ExpiresAt { get; init; }

    public bool IsExpired(DateTimeOffset timeNow) => ExpiresAt <= timeNow;

    public static OAuth2AccessToken FromResponse(ClientCredentialsResponse response) =>
        new()
        {
            AccessToken = response.AccessToken,
            ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(response.ExpiresIn)
        };
}

public interface IOAuth2ClientCredentialsProvider
{
    ValueTask<OAuth2AccessToken> GetAsync(CancellationToken ct);
}


public sealed class OAuth2ClientCredentialsProvider
{
    private readonly RawClient _rawClient;

    public OAuth2ClientCredentialsProvider(RawClient rawClient)
    {
        _rawClient = rawClient;
    }

    public Task<ClientCredentialsResponse> GetToken(string clientId, string clientSecret, string grantType,
        CancellationToken cancellationToken) =>
        _rawClient.Execute(
            "/oauth2/token",
            [],
            [],
            [],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create([new Param("client_id", clientId), new Param("client_secret", clientSecret), new Param("grant_type", grantType)]),
            JsonResponse.Create<ClientCredentialsResponse>(),
            VoidErrorResponse.Instance,
            [],
            cancellationToken);
}

public class ClientCredentialsRequest
{
    [JsonPropertyName("grant_type")]
    public string GrantType { get; init; } = "client_credentials";

    [JsonPropertyName("client_id")]
    public required string ClientId { get; init; }

    [JsonPropertyName("client_secret")]
    public required string ClientSecret { get; init; }

    [JsonPropertyName("scope")]
    public string? Scope { get; init; }
}

public sealed class ClientCredentialsResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; } = null!;

    [JsonPropertyName("token_type")]
    public required string TokenType { get; init; } = "Bearer";

    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }

    [JsonPropertyName("scope")]
    public string? Scope { get; init; }
}
