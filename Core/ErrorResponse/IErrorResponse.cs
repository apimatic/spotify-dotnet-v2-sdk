namespace SpotifyWebApi.Core.ErrorResponse;

public interface IErrorResponse<out TError>
{
    public TError Deserialize(int statusCode, string content);
}