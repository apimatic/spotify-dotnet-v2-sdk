using SpotifyWebApi.Core.Authentication;
using SpotifyWebApi.Core.Request;

namespace SpotifyWebApi.Core.Models;

public  class ApiRequest
{
    public string Path { get; }
    public IReadOnlyCollection<TemplateParam> TemplateParameters { get; }
    public IReadOnlyCollection<Param> QueryParameters { get; }
    public IReadOnlyCollection<HeaderParam> HeaderParameters { get; }
    public HttpMethod HttpMethod { get; }
    public IRequest Request { get; }
    public IReadOnlyList<IAuthScheme> AuthPolicies { get; }

    public ApiRequest(string path,
        IReadOnlyCollection<TemplateParam> templateParameters,
        IReadOnlyCollection<Param> queryParameters,
        IReadOnlyCollection<HeaderParam> headerParameters,
        HttpMethod httpMethod,
        IRequest request,
        IReadOnlyList<IAuthScheme> authPolicies)
    {
        Path = path;
        TemplateParameters = templateParameters;
        QueryParameters = queryParameters;
        HeaderParameters = headerParameters;
        HttpMethod = httpMethod;
        Request = request;
        AuthPolicies = authPolicies;
    }
}