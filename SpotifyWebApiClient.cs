using SpotifyWebApi.Authentication;
using SpotifyWebApi.Core;
using SpotifyWebApi.Core.Authentication;
using SpotifyWebApi.Core.ErrorResponse;
using SpotifyWebApi.Core.Models;
using SpotifyWebApi.Core.Request;
using SpotifyWebApi.Core.Response;
using SpotifyWebApi.Models;

namespace SpotifyWebApi;

public class SpotifyWebApiClient
{
    private readonly RawClient _rawClient;
    private readonly IAuthScheme _bearerAuthScheme;

    public SpotifyWebApiClient(HttpClient httpClient, SpotifyWebApiClientOptions options, string? bearerToken)
    {
        const string baseUrl = "https://api.spotify.com/v1";
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(baseUrl, queryParameterFactory, templateParamsFactory);
        var responseStatusChecker = new ResponseStatusChecker([]);
        var headersFactory = new HeadersFactory([]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.RetryOptions);
        _rawClient =
            new RawClient(httpClient, urlFactory, responseStatusChecker, headersFactory, resiliencePipelineFactory);
        _bearerAuthScheme = bearerToken != null
            ? new BearerAuthScheme(bearerToken)
            : NoneAuthScheme.Instance;
    }

    public Task<AlbumObject> GetAnAlbum(string id, string? market, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/albums/{id}",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AlbumObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyAlbums> GetMultipleAlbums(string ids,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/albums",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyAlbums>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSimplifiedTrackObject> GetAnAlbumsTracks(string id,
        string? market,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/albums/{id}/tracks",
            [new TemplateParam("id", id)],
            [new Param("market", market), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSimplifiedTrackObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSavedAlbumObject> GetUsersSavedAlbums(double? limit,
        double? offset,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/albums",
            [],
            [new Param("limit", limit), new Param("offset", offset), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSavedAlbumObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SaveAlbumsUser(string ids, MeAlbumsRequest? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/albums",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task RemoveAlbumsUser(string ids, MeAlbumsRequest? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/albums",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckUsersSavedAlbums(string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/albums/contains",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagedAlbums> GetNewReleases(double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/browse/new-releases",
            [],
            [new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagedAlbums>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ArtistObject> GetAnArtist(string id, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/artists/{id}",
            [new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ArtistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyArtists> GetMultipleArtists(string ids, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/artists",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyArtists>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingArtistDiscographyAlbumObject> GetAnArtistsAlbums(string id,
        string? includeGroups,
        string? market,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/artists/{id}/albums",
            [new TemplateParam("id", id)],
            [new Param("include_groups", includeGroups),
                new Param("market", market),
                new Param("limit", limit),
                new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingArtistDiscographyAlbumObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyTracks> GetAnArtistsTopTracks(string id,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/artists/{id}/top-tracks",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyTracks>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyArtists> GetAnArtistsRelatedArtists(string id, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/artists/{id}/related-artists",
            [new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyArtists>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<AudiobookObject> GetAnAudiobook(string id,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/audiobooks/{id}",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AudiobookObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyAudiobooks> GetMultipleAudiobooks(string ids,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/audiobooks",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyAudiobooks>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSimplifiedChapterObject> GetAudiobookChapters(string id,
        string? market,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/audiobooks/{id}/chapters",
            [new TemplateParam("id", id)],
            [new Param("market", market), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSimplifiedChapterObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSavedAudiobookObject> GetUsersSavedAudiobooks(double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/audiobooks",
            [],
            [new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSavedAudiobookObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SaveAudiobooksUser(string ids, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/audiobooks",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task RemoveAudiobooksUser(string ids, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/audiobooks",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckUsersSavedAudiobooks(string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/audiobooks/contains",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagedCategories> GetCategories(string? locale,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/browse/categories",
            [],
            [new Param("locale", locale), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagedCategories>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<CategoryObject> GetACategory(string categoryId,
        string? locale,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/browse/categories/{category_id}",
            [new TemplateParam("category_id", categoryId)],
            [new Param("locale", locale)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CategoryObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ChapterObject> GetAChapter(string id, string? market, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/chapters/{id}",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ChapterObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyChapters> GetSeveralChapters(string ids,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/chapters",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyChapters>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<EpisodeObject> GetAnEpisode(string id,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/episodes/{id}",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<EpisodeObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyEpisodes> GetMultipleEpisodes(string ids,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/episodes",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyEpisodes>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSavedEpisodeObject> GetUsersSavedEpisodes(string? market,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/episodes",
            [],
            [new Param("market", market), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSavedEpisodeObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SaveEpisodesUser(string ids, MeEpisodesRequest? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/episodes",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task RemoveEpisodesUser(string ids,
        MeEpisodesRequest1? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/episodes",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckUsersSavedEpisodes(string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/episodes/contains",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyGenres> GetRecommendationGenres(CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/recommendations/available-genre-seeds",
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyGenres>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<Markets> GetAvailableMarkets(CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/markets",
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Markets>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<CurrentlyPlayingContextObject> GetInformationAboutTheUsersCurrentPlayback(string? market,
        string? additionalTypes,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player",
            [],
            [new Param("market", market), new Param("additional_types", additionalTypes)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CurrentlyPlayingContextObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task TransferAUsersPlayback(MePlayerRequest? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player",
            [],
            [],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyDevices> GetAUsersAvailableDevices(CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/devices",
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyDevices>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<CurrentlyPlayingObject> GetTheUsersCurrentlyPlayingTrack(string? market,
        string? additionalTypes,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/currently-playing",
            [],
            [new Param("market", market), new Param("additional_types", additionalTypes)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CurrentlyPlayingObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task StartAUsersPlayback(string? deviceId,
        MePlayerPlayRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/play",
            [],
            [new Param("device_id", deviceId)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task PauseAUsersPlayback(string? deviceId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/pause",
            [],
            [new Param("device_id", deviceId)],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SkipUsersPlaybackToNextTrack(string? deviceId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/next",
            [],
            [new Param("device_id", deviceId)],
            [],
            HttpMethod.Post,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SkipUsersPlaybackToPreviousTrack(string? deviceId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/previous",
            [],
            [new Param("device_id", deviceId)],
            [],
            HttpMethod.Post,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SeekToPositionInCurrentlyPlayingTrack(double positionMs,
        string? deviceId,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/seek",
            [],
            [new Param("position_ms", positionMs), new Param("device_id", deviceId)],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SetRepeatModeOnUsersPlayback(string state,
        string? deviceId,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/repeat",
            [],
            [new Param("state", state), new Param("device_id", deviceId)],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SetVolumeForUsersPlayback(double volumePercent,
        string? deviceId,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/volume",
            [],
            [new Param("volume_percent", volumePercent), new Param("device_id", deviceId)],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task ToggleShuffleForUsersPlayback(bool state,
        string? deviceId,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/shuffle",
            [],
            [new Param("state", state), new Param("device_id", deviceId)],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<CursorPagingPlayHistoryObject> GetRecentlyPlayed(double? limit,
        long? after,
        double? before,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/recently-played",
            [],
            [new Param("limit", limit), new Param("after", after), new Param("before", before)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CursorPagingPlayHistoryObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<QueueObject> GetQueue(CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/queue",
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<QueueObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task AddToQueue(string uri, string? deviceId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/player/queue",
            [],
            [new Param("uri", uri), new Param("device_id", deviceId)],
            [],
            HttpMethod.Post,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PlaylistObject> GetPlaylist(string playlistId,
        string? market,
        string? fields,
        string? additionalTypes,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}",
            [new TemplateParam("playlist_id", playlistId)],
            [new Param("market", market),
                new Param("fields", fields),
                new Param("additional_types", additionalTypes)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PlaylistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task ChangePlaylistDetails(string playlistId,
        PlaylistsRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}",
            [new TemplateParam("playlist_id", playlistId)],
            [],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingPlaylistTrackObject> GetPlaylistsTracks(string playlistId,
        string? market,
        string? fields,
        double? limit,
        double? offset,
        string? additionalTypes,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/tracks",
            [new TemplateParam("playlist_id", playlistId)],
            [new Param("market", market),
                new Param("fields", fields),
                new Param("limit", limit),
                new Param("offset", offset),
                new Param("additional_types", additionalTypes)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingPlaylistTrackObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PlaylistSnapshotId> AddTracksToPlaylist(string playlistId,
        double? position,
        string? uris,
        PlaylistsTracksRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/tracks",
            [new TemplateParam("playlist_id", playlistId)],
            [new Param("position", position), new Param("uris", uris)],
            [],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<PlaylistSnapshotId>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PlaylistSnapshotId> ReorderOrReplacePlaylistsTracks(string playlistId,
        string? uris,
        PlaylistsTracksRequest1? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/tracks",
            [new TemplateParam("playlist_id", playlistId)],
            [new Param("uris", uris)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<PlaylistSnapshotId>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PlaylistSnapshotId> RemoveTracksPlaylist(string playlistId,
        PlaylistsTracksRequest2? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/tracks",
            [new TemplateParam("playlist_id", playlistId)],
            [],
            [],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            JsonResponse.Create<PlaylistSnapshotId>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingPlaylistObject> GetAListOfCurrentUsersPlaylists(double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/playlists",
            [],
            [new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingPlaylistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingPlaylistObject> GetListUsersPlaylists(string userId,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/users/{user_id}/playlists",
            [new TemplateParam("user_id", userId)],
            [new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingPlaylistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PlaylistObject> CreatePlaylist(string userId,
        UsersPlaylistsRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/users/{user_id}/playlists",
            [new TemplateParam("user_id", userId)],
            [],
            [],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<PlaylistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingFeaturedPlaylistObject> GetFeaturedPlaylists(string? locale,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/browse/featured-playlists",
            [],
            [new Param("locale", locale), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingFeaturedPlaylistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingFeaturedPlaylistObject> GetACategoriesPlaylists(string categoryId,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/browse/categories/{category_id}/playlists",
            [new TemplateParam("category_id", categoryId)],
            [new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingFeaturedPlaylistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<ImageObject>> GetPlaylistCover(string playlistId,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/images",
            [new TemplateParam("playlist_id", playlistId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<ImageObject>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task UploadCustomPlaylistCover(string playlistId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/images",
            [new TemplateParam("playlist_id", playlistId)],
            [],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<SearchItems> Search(string q,
        IReadOnlyList<ItemType> type,
        string? market,
        double? limit,
        double? offset,
        IncludeExternal? includeExternal,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/search",
            [],
            [new Param("q", q),
                new Param("type", type),
                new Param("market", market),
                new Param("limit", limit),
                new Param("offset", offset),
                new Param("include_external", includeExternal)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SearchItems>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ShowObject> GetAShow(string id, string? market, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/shows/{id}",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ShowObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManySimplifiedShows> GetMultipleShows(string ids,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/shows",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManySimplifiedShows>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSimplifiedEpisodeObject> GetAShowsEpisodes(string id,
        string? market,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/shows/{id}/episodes",
            [new TemplateParam("id", id)],
            [new Param("market", market), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSimplifiedEpisodeObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSavedShowObject> GetUsersSavedShows(double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/shows",
            [],
            [new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSavedShowObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SaveShowsUser(string ids, MeShowsRequest? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/shows",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task RemoveShowsUser(string ids,
        string? market,
        MeShowsRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/shows",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckUsersSavedShows(string ids, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/shows/contains",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<TrackObject> GetTrack(string id, string? market, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/tracks/{id}",
            [new TemplateParam("id", id)],
            [new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TrackObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyTracks> GetSeveralTracks(string ids,
        string? market,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/tracks",
            [],
            [new Param("ids", ids), new Param("market", market)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyTracks>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingSavedTrackObject> GetUsersSavedTracks(string? market,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/tracks",
            [],
            [new Param("market", market), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingSavedTrackObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task SaveTracksUser(string ids, MeTracksRequest? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/tracks",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task RemoveTracksUser(string ids, MeTracksRequest1? body, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/tracks",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckUsersSavedTracks(string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/tracks/contains",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<ManyAudioFeatures> GetSeveralAudioFeatures(string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/audio-features",
            [],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ManyAudioFeatures>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<AudioFeaturesObject> GetAudioFeatures(string id, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/audio-features/{id}",
            [new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AudioFeaturesObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<AudioAnalysisObject> GetAudioAnalysis(string id, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/audio-analysis/{id}",
            [new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<AudioAnalysisObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<RecommendationsObject> GetRecommendations(double? limit,
        string? market,
        string? seedArtists,
        string? seedGenres,
        string? seedTracks,
        decimal? minAcousticness,
        decimal? maxAcousticness,
        decimal? targetAcousticness,
        decimal? minDanceability,
        decimal? maxDanceability,
        decimal? targetDanceability,
        double? minDurationMs,
        double? maxDurationMs,
        double? targetDurationMs,
        decimal? minEnergy,
        decimal? maxEnergy,
        decimal? targetEnergy,
        decimal? minInstrumentalness,
        decimal? maxInstrumentalness,
        decimal? targetInstrumentalness,
        double? minKey,
        double? maxKey,
        double? targetKey,
        decimal? minLiveness,
        decimal? maxLiveness,
        decimal? targetLiveness,
        decimal? minLoudness,
        decimal? maxLoudness,
        decimal? targetLoudness,
        double? minMode,
        double? maxMode,
        double? targetMode,
        double? minPopularity,
        double? maxPopularity,
        double? targetPopularity,
        decimal? minSpeechiness,
        decimal? maxSpeechiness,
        decimal? targetSpeechiness,
        decimal? minTempo,
        decimal? maxTempo,
        decimal? targetTempo,
        double? minTimeSignature,
        double? maxTimeSignature,
        double? targetTimeSignature,
        decimal? minValence,
        decimal? maxValence,
        decimal? targetValence,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/recommendations",
            [],
            [new Param("limit", limit),
                new Param("market", market),
                new Param("seed_artists", seedArtists),
                new Param("seed_genres", seedGenres),
                new Param("seed_tracks", seedTracks),
                new Param("min_acousticness", minAcousticness),
                new Param("max_acousticness", maxAcousticness),
                new Param("target_acousticness", targetAcousticness),
                new Param("min_danceability", minDanceability),
                new Param("max_danceability", maxDanceability),
                new Param("target_danceability", targetDanceability),
                new Param("min_duration_ms", minDurationMs),
                new Param("max_duration_ms", maxDurationMs),
                new Param("target_duration_ms", targetDurationMs),
                new Param("min_energy", minEnergy),
                new Param("max_energy", maxEnergy),
                new Param("target_energy", targetEnergy),
                new Param("min_instrumentalness", minInstrumentalness),
                new Param("max_instrumentalness", maxInstrumentalness),
                new Param("target_instrumentalness", targetInstrumentalness),
                new Param("min_key", minKey),
                new Param("max_key", maxKey),
                new Param("target_key", targetKey),
                new Param("min_liveness", minLiveness),
                new Param("max_liveness", maxLiveness),
                new Param("target_liveness", targetLiveness),
                new Param("min_loudness", minLoudness),
                new Param("max_loudness", maxLoudness),
                new Param("target_loudness", targetLoudness),
                new Param("min_mode", minMode),
                new Param("max_mode", maxMode),
                new Param("target_mode", targetMode),
                new Param("min_popularity", minPopularity),
                new Param("max_popularity", maxPopularity),
                new Param("target_popularity", targetPopularity),
                new Param("min_speechiness", minSpeechiness),
                new Param("max_speechiness", maxSpeechiness),
                new Param("target_speechiness", targetSpeechiness),
                new Param("min_tempo", minTempo),
                new Param("max_tempo", maxTempo),
                new Param("target_tempo", targetTempo),
                new Param("min_time_signature", minTimeSignature),
                new Param("max_time_signature", maxTimeSignature),
                new Param("target_time_signature", targetTimeSignature),
                new Param("min_valence", minValence),
                new Param("max_valence", maxValence),
                new Param("target_valence", targetValence)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<RecommendationsObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PrivateUserObject> GetCurrentUsersProfile(CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me",
            [],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PrivateUserObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PublicUserObject> GetUsersProfile(string userId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/users/{user_id}",
            [new TemplateParam("user_id", userId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PublicUserObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task FollowPlaylist(string playlistId,
        PlaylistsFollowersRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/followers",
            [new TemplateParam("playlist_id", playlistId)],
            [],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task UnfollowPlaylist(string playlistId, CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/followers",
            [new TemplateParam("playlist_id", playlistId)],
            [],
            [],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<CursorPagedArtists> GetFollowed(ItemType1 type,
        string? after,
        double? limit,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/following",
            [],
            [new Param("type", type), new Param("after", after), new Param("limit", limit)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CursorPagedArtists>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task FollowArtistsUsers(ItemType2 type,
        string ids,
        MeFollowingRequest? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/following",
            [],
            [new Param("type", type), new Param("ids", ids)],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task UnfollowArtistsUsers(ItemType3 type,
        string ids,
        MeFollowingRequest1? body,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/following",
            [],
            [new Param("type", type), new Param("ids", ids)],
            [],
            HttpMethod.Delete,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckCurrentUserFollows(ItemType3 type,
        string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/following/contains",
            [],
            [new Param("type", type), new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<IReadOnlyList<bool>> CheckIfUserFollowsPlaylist(string playlistId,
        string ids,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/playlists/{playlist_id}/followers/contains",
            [new TemplateParam("playlist_id", playlistId)],
            [new Param("ids", ids)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyList<bool>>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingArtistObject> GetUsersTopArtists(string? timeRange,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/top/artists",
            [],
            [new Param("time_range", timeRange), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingArtistObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);

    public Task<PagingTrackObject> GetUsersTopTracks(string? timeRange,
        double? limit,
        double? offset,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute("/me/top/tracks",
            [],
            [new Param("time_range", timeRange), new Param("limit", limit), new Param("offset", offset)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<PagingTrackObject>(),
            VoidErrorResponse.Instance,
            [_bearerAuthScheme],
            cancellationToken);
}
