using System.Runtime.CompilerServices;
using SpotifyWebApi.Core.Authentication;
using SpotifyWebApi.Core.ErrorResponse;
using SpotifyWebApi.Core.Extensions;
using SpotifyWebApi.Core.Models;
using SpotifyWebApi.Core.Request;
using SpotifyWebApi.Core.Response;

namespace SpotifyWebApi.Core;

public class RawClient
{
    private readonly HeadersFactory _headerFactory;
    private readonly HttpClient _httpClient;
    private readonly ResponseStatusChecker _responseStatusChecker;
    private readonly UriFactory _uriFactory;
    private readonly ResiliencePipelineFactory _resiliencePipelineFactory;

    public RawClient(HttpClient httpClient, UriFactory uriFactory,
        ResponseStatusChecker responseStatusChecker, HeadersFactory headerFactory, ResiliencePipelineFactory resiliencePipelineFactory)
    {
        _httpClient = httpClient;
        _uriFactory = uriFactory;
        _responseStatusChecker = responseStatusChecker;
        _headerFactory = headerFactory; 
        _resiliencePipelineFactory = resiliencePipelineFactory;
    }

    public async Task<ApiResult<TResponse, TError>> ExecuteResult<TResponse, TError>(
        string path,
        IReadOnlyCollection<TemplateParam> templateParameters,
        IReadOnlyCollection<Param> queryParameters,
        IReadOnlyCollection<HeaderParam> headerParameters,
        HttpMethod httpMethod,
        IRequest request,
        IResponse<TResponse> response,
        IErrorResponse<TError> errorResponseDeserializer,
        IReadOnlyList<IAuthScheme> authPolicies,
        CancellationToken cancellationToken)
    {
        var uri = _uriFactory.Create(path, queryParameters, templateParameters);
        var headers = _headerFactory.Create(headerParameters);

        var pipeline = _resiliencePipelineFactory.Create(request);

        // Execute request with retry policy
        using var httpResponseMessage = await pipeline.ExecuteAsync(async ct =>
        {
            using var httpRequest = new HttpRequestMessage(httpMethod, uri);
            httpRequest.Content = request.Get();
            httpRequest.Headers.Add(headers);
            await authPolicies.Apply(httpRequest, ct);
            return await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, ct)
                .ConfigureAwait(false);
        }, cancellationToken).ConfigureAwait(false);

        if (_responseStatusChecker.CheckSuccess(httpResponseMessage))
        {
            var serializedResponse = await response.Map(httpResponseMessage, cancellationToken).ConfigureAwait(false);
            return ApiResult<TResponse, TError>.Success(
                serializedResponse!,
                httpResponseMessage.StatusCode,
                httpResponseMessage.Headers);
        }

        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        var errorResponse = errorResponseDeserializer.Deserialize((int)httpResponseMessage.StatusCode, responseBody);

        return ApiResult<TResponse, TError>.Failure(
            errorResponse!,
            httpResponseMessage.StatusCode,
            httpResponseMessage.Headers);
    }


    public async Task<TResponse> Execute<TResponse, TError>(
        string path,
        IReadOnlyCollection<TemplateParam> templateParameters,
        IReadOnlyCollection<Param> queryParameters,
        IReadOnlyCollection<HeaderParam> headerParameters,
        HttpMethod httpMethod,
        IRequest request,
        IResponse<TResponse> response,
        IErrorResponse<TError> errorResponseDeserializer,
        IReadOnlyList<IAuthScheme> authPolicies,
        CancellationToken cancellationToken) =>
        (await ExecuteResult(
            path,
            templateParameters,
            queryParameters,
            headerParameters,
            httpMethod,
            request,
            response,
            errorResponseDeserializer,
            authPolicies,
            cancellationToken).ConfigureAwait(false)).GetResponseOrThrow();

    public async IAsyncEnumerable<TItem> ExecutePagedItems<TResponse, TState, TItem, TError>(
        TState initialState,
        Func<TState, ApiRequest> requestFactory,
        Func<TResponse, IReadOnlyList<TItem>> getItems,
        Func<TResponse, TState, TState?> getNextState,
        ApiResponse<TResponse, TError> response,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var result in ExecutePagedResults(
                           initialState,
                           requestFactory,
                           getNextState,
                           response,
                           ct))
        {
            var successResponse = result.GetResponseOrThrow();
            foreach (var item in getItems(successResponse))
            {
                yield return item;
            }
        }
    }
    
    
    public async Task<ApiResult<TResponse, TError>> ExecuteResultNew<TResponse, TError>(
        ApiRequest request,
        ApiResponse<TResponse, TError> response,
        CancellationToken cancellationToken)
    {

        var uri = _uriFactory.Create(request.Path, request.QueryParameters, request.TemplateParameters);
        var headers = _headerFactory.Create(request.HeaderParameters);

        
        var pipeline = _resiliencePipelineFactory.Create(request.Request);
        
        // Execute request with retry policy
        using var httpResponseMessage = await pipeline.ExecuteAsync(async ct =>
        {
            using var httpRequest = new HttpRequestMessage(request.HttpMethod, uri);
            httpRequest.Content = request.Request.Get();
            httpRequest.Headers.Add(headers);
            await request.AuthPolicies.Apply(httpRequest, ct);
            return await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, ct)
                .ConfigureAwait(false);
        }, cancellationToken).ConfigureAwait(false);

        if (_responseStatusChecker.CheckSuccess(httpResponseMessage))
        {
            var serializedResponse = await response.Response.Map(httpResponseMessage, cancellationToken).ConfigureAwait(false);
            return ApiResult<TResponse, TError>.Success(
                serializedResponse!, 
                httpResponseMessage.StatusCode,
                httpResponseMessage.Headers);
        }

        var responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        var errorResponse = response.ErrorResponseDeserializer.Deserialize((int)httpResponseMessage.StatusCode, responseBody);

        return ApiResult<TResponse, TError>.Failure(
            errorResponse!,
            httpResponseMessage.StatusCode,
            httpResponseMessage.Headers);
    }

    public async IAsyncEnumerable<IReadOnlyList<TItem>> ExecutePagedPages<TResponse, TState, TItem, TError>(
        TState initialState,
        Func<TState, ApiRequest> requestFactory,
        Func<TResponse, IReadOnlyList<TItem>> getItems,
        Func<TResponse, TState, TState?> getNextState,
        ApiResponse<TResponse, TError> response,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var result in ExecutePagedResults(
                           initialState,
                           requestFactory,
                           getNextState,
                           response,
                           ct))
        {
            var successResponse = result.GetResponseOrThrow();
            yield return getItems(successResponse);
        }
    }

    public async IAsyncEnumerable<ApiResult<TResponse, TError>> ExecutePagedResults<TResponse, TState, TError>(
        TState initialState,
        Func<TState, ApiRequest> requestFactory,
        Func<TResponse, TState, TState?> getNextState,
        ApiResponse<TResponse, TError> response,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var state = initialState;

        while (true)
        {
            var request = requestFactory(state);

            var result = await ExecuteResultNew(
                request,
                response,
                ct
            ).ConfigureAwait(false);

            yield return result;

            if (!result.TryGetResponse(out var successResponse))
            {
                yield break;
            }

            var next = getNextState(successResponse, state);
            if (next == null)
            {
                yield break;
            }

            state = next;
        }
    }
}