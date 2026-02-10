using SpotifyWebApi.Core.Models;

namespace SpotifyWebApi.Core;

public class UriFactory
{
    private readonly string _baseUrl;
    private readonly QueryParameterFactory _factory;
    private readonly TemplateParamsFactory _templateParamsFactory;

    public UriFactory(string baseUrl, QueryParameterFactory factory, TemplateParamsFactory templateParamsFactory)
    {
        _baseUrl = baseUrl;
        _factory = factory;
        _templateParamsFactory = templateParamsFactory;
    }

    public Uri Create(string path, IReadOnlyCollection<Param> queryParameters,
        IReadOnlyCollection<TemplateParam> templateParams)
    {
        var hostPath = _templateParamsFactory.Create($"{_baseUrl}{path}", templateParams);

        if (queryParameters.Count == 0)
            return new Uri(hostPath);

        var queryString = _factory.Serialize(queryParameters);
        return new Uri($"{hostPath}?{queryString}");
    }
}