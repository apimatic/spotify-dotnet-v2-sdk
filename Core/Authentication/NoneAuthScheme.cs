namespace SpotifyWebApi.Core.Authentication;

public class NoneAuthScheme: IAuthScheme
{
    public ValueTask Apply(HttpRequestMessage request, CancellationToken ct) => default;


    public static readonly NoneAuthScheme Instance = new();

    private NoneAuthScheme()
    {
    }
}