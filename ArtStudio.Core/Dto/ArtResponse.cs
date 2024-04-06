namespace ArtStudio.Core.Dto;

public record ArtResponse(
    Guid Id, 
    DateTime CreatedOn, 
    string Name, 
    decimal Price, 
    string Description);