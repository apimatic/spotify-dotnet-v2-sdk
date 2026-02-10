using System.Net;

namespace SpotifyWebApi.Core;

public class ResponseStatusChecker
{
    private readonly IReadOnlyCollection<HttpStatusCode> _successCodes;

    public ResponseStatusChecker(IReadOnlyCollection<HttpStatusCode> successCodes) => _successCodes = successCodes;

    public bool CheckSuccess(HttpResponseMessage httpResponseMessage) =>
        _successCodes.Count > 0
            ? _successCodes.Contains(httpResponseMessage.StatusCode)
            : httpResponseMessage.IsSuccessStatusCode;
}