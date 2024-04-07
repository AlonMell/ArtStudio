namespace ArtStudio.Core.Dto;

public record ArtUpdateRequest(
    string? Name,
    decimal? Price,
    string? Description);
