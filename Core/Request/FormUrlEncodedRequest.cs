using SpotifyWebApi.Core.Models;

namespace SpotifyWebApi.Core.Request;

public class FormUrlEncodedRequest : IRequest
{
    private readonly IReadOnlyCollection<Param> _params;

    private FormUrlEncodedRequest(IReadOnlyCollection<Param> @params) => _params = @params;

    public HttpContent Get()
    {
        var paris = _params.SelectMany(ParameterFlattener.Flatten).ToList();
        return new FormUrlEncodedContent(paris);
    }

    public bool CanRetry => true;

    public static FormUrlEncodedRequest Create(IReadOnlyCollection<Param> @params) => new(@params);
}