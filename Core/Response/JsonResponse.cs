using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpotifyWebApi.Core.Response;

public class JsonResponse<TResponse> : IResponse<TResponse>
{
    private readonly JsonConverter? _jsonConverter;

    public JsonResponse(JsonConverter? jsonConverter) => _jsonConverter = jsonConverter;

    public async Task<TResponse?> Map(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken)
    {
#if NET6_0_OR_GREATER
        var responseStream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
#else
        var responseStream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
        if (_jsonConverter == null) return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        var options = new JsonSerializerOptions { Converters = { _jsonConverter } };
        return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, options, cancellationToken).ConfigureAwait(false);
    }
}

public static class JsonResponse
{
    public static JsonResponse<TResponse> Create<TResponse>(JsonConverter? converter = null) => new(converter);
}