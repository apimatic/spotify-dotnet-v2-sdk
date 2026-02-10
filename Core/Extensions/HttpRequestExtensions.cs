using System.Net.Http.Headers;
using SpotifyWebApi.Core.Models;

namespace SpotifyWebApi.Core.Extensions;

public static class HttpRequestExtensions
{
    extension(HttpRequestHeaders requestHeaders)
    {
        public void Add(IReadOnlyCollection<HeaderParam> headers)
        {
            foreach (var header in headers)
                requestHeaders.Add(header.Key, header.Value);
        }
    }
}