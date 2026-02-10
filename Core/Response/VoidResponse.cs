namespace SpotifyWebApi.Core.Response;

public sealed class VoidResponse :  IResponse<VoidResponse>
{
    public Task<VoidResponse?> Map(HttpResponseMessage httpResponseMessage, CancellationToken cancellationToken) =>
        Task.FromResult(Instance)!;
    

    public static VoidResponse Instance { get; } =  new();
}