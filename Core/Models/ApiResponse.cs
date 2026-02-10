using SpotifyWebApi.Core.ErrorResponse;
using SpotifyWebApi.Core.Response;

namespace SpotifyWebApi.Core.Models;

public class ApiResponse<TResponse, TError>
{
    public IResponse<TResponse> Response { get; }
    public IErrorResponse<TError> ErrorResponseDeserializer { get; }

    public ApiResponse(IResponse<TResponse> response, IErrorResponse<TError> errorResponseDeserializer)
    {
        Response = response;
        ErrorResponseDeserializer = errorResponseDeserializer;
    }
}

public static class ApiResponse
{
    public static ApiResponse<TResponse, TError> Create<TResponse, TError>(IResponse<TResponse> response,
        IErrorResponse<TError> errorResponseDeserializer) =>
        new(response, errorResponseDeserializer);
}
