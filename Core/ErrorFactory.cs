using System.Text.Json;

namespace SpotifyWebApi.Core;


public class ErrorFactory
{
    public async Task<TError> Create<TError>(HttpResponseMessage response)
    {
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var error = JsonSerializer.Deserialize<TError>(responseBody);
        return error!;
    }
    
    public async Task<TError> Map<TError>(HttpResponseMessage response, Func<int, string, TError> error)
    {
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return error((int)response.StatusCode, responseBody);
    }
}