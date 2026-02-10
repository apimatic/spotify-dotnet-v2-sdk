using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotifyWebApi.Core.Response;

public class VectorResponse<TResponse> : IResponse<TResponse>
{
    private readonly JsonConverter _converter;

    public VectorResponse(JsonConverter converter) => _converter = converter;

    public async Task<TResponse?> Map(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken)
    {
        // TODO: Add cancellation token with conditional compilation
        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        var options = new JsonSerializerOptions { Converters = { _converter } };
        return JsonSerializer.Deserialize<TResponse>(responseBody, options);
    }
}

public static class VectorResponse
{
    public static VectorResponse<TResponse> Create<TResponse>(JsonConverter converter) => new(converter);
}