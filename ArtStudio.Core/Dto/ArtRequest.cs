namespace ArtStudio.Core.Dto; 
public record ArtRequest(
    Guid? Id,
    string? Name, 
    decimal? Price, 
    string? Description);
