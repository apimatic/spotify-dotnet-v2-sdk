# Getting Started with SpotifyWebApi

You can use Spotify's Web API to discover music and podcasts, manage your Spotify library, control audio playback, and much more. Browse our available Web API endpoints using the sidebar at left, or via the navigation bar on top of this page on smaller screens.

In order to make successful Web API requests your app will need a valid access token. One can be obtained through [OAuth 2.0](https://developer.spotify.com/documentation/general/guides/authorization-guide/).

The base URI for all Web API requests is `https://api.spotify.com/v1`.

Need help? See our [Web API guides](https://developer.spotify.com/documentation/web-api/guides/) for more information, or visit the [Spotify for Developers community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer) to ask questions and connect with other developers.

version: 2024.3.3

---

## Installation

Install this SDK into your application by adding a project reference to the SDK.

```bash
dotnet add reference <path-to-sdk>\SpotifyWebApi.csproj
```

---

## Usage

```csharp
using SpotifyWebApi;
using SpotifyWebApi.Models;

string bearerToken = "1POdFZRZbvb...qqillRxMr2z";
SpotifyWebApiClient client = new SpotifyWebApiClient(new HttpClient(), new SpotifyWebApiClientOptions(), bearerToken);

try
{
    PlaylistObject playlist = await client.CreatePlaylist(
        userId: "smedjan",
        body: new UsersPlaylistsRequest
        {
            Name = "My API Playlist",
            Public = false,
            Collaborative = true,
            Description = "Created via Spotify Web API"
        }
    );
    // TODO: decide what happens when api call is successfully completed
}
catch (SdkException<VoidErrorResponse> ex)
{
    // TODO: decide what happens when api call is resulted in an error status code
}
```

## Client Options

The following options are configurable in your client:

| Parameter | Type | Description |
|  --- | --- | --- |
| RetryOptions | [`RetryOptions`](#retry-options) | The Retry options for the API Calls |

### Retry Options

The following fields are available in `RetryOptions`:

| Parameter | Type | Description |
|  --- | --- | --- |
| Timeout | `TimeSpan` | Per-request timeout; cancels requests exceeding this duration. <br> **Default: 100s** |
| StatusCodesToRetry | `IReadOnlyList<HttpStatusCode>` | HTTP status codes that trigger a retry. <br> **Default: 408, 429, 500, 502, 503, 504** |
| HttpMethodsToRetry | `IReadOnlyList<HttpMethod>` | HTTP methods eligible for retry. <br> **Default: GET, HEAD, PUT, OPTIONS** |
| MaxRetries | `int` | Maximum number of retry attempts. <br> **Default: 3** |
| Delay | `TimeSpan` | Base delay before each retry attempt. <br> **Default: 1s** |
| BackOffFactor | `int` | Multiplier for exponential backoff (e.g., 2 doubles each attempt's delay). <br> **Default: 2** |
| UseExponentialBackoff | `bool` | Enables exponential backoff; when false, uses constant delay. <br> **Default: true** |
| MaxJitter | `TimeSpan` | Maximum random jitter added to delay to reduce contention. <br> **Default: 500ms** |
| OnRetry | `Action<Exception, TimeSpan, int>` | Callback invoked on each retry with the error/result, applied delay, and attempt number. <br> **Default: null** |

---

## Retries and BackOff

```csharp
using SpotifyWebApi;
using SpotifyWebApi.Models;

SpotifyWebApiClientOptions options =
    new SpotifyWebApiClientOptions
    {
        RetryOptions = SpotifyWebApi.Core.Configuration.RetryOptions.Default() with
        {
            MaxRetries = 5,
            Delay = TimeSpan.FromSeconds(2)
        }
    };
    

SpotifyWebApiClient client = new SpotifyWebApiClient(new HttpClient(), options, bearerToken);

// Make any API Call with HttpMethod GET
PagingPlaylistObject pagingPlaylistObject = await client.GetListUsersPlaylists("smedjan", 20, 5);
```

## Bearer Authentication

```csharp
using SpotifyWebApi;
using SpotifyWebApi.Models;

// Initialize Client with bearer authentication
string bearerToken = "1POdFZRZbvb...qqillRxMr2z";
SpotifyWebApiClient client = new SpotifyWebApiClient(new HttpClient(), new SpotifyWebApiClientOptions(), bearerToken);


// Make an API Call that requires authentication
PagingPlaylistObject pagingPlaylistObject = await client.GetListUsersPlaylists("smedjan", 20, 5);
```