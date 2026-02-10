namespace SpotifyWebApi.Core.Pagination;

public sealed record OffsetState(int Offset, int Limit);

public sealed record CursorState(string? Cursor, int Limit);

public sealed record LinkState(string NextLink);
