using System.Net.Http.Json;

namespace SpotifyWebApi.Core.Request;

public class JsonRequest<TData> : IRequest
{
    private readonly TData _data;

    public JsonRequest(TData data) => _data = data;

    public HttpContent Get() => JsonContent.Create(_data);
    public bool CanRetry => true;
}

public static class JsonRequest
{
    public static JsonRequest<TData> Create<TData>(TData data) => new(data);
}