namespace SpotifyWebApi.Core.ErrorResponse;

public sealed class VoidErrorResponse : IErrorResponse<VoidErrorResponse>
{
    public static VoidErrorResponse Instance { get; } = new();

    private VoidErrorResponse()
    {
    }

    public VoidErrorResponse Deserialize(int statusCode, string content) => new();
}