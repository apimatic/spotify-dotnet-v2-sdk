using SpotifyWebApi.Core.Configuration;

namespace SpotifyWebApi;

public class SpotifyWebApiClientOptions
{
    public RetryOptions RetryOptions { get; init; } = RetryOptions.Default();
}
