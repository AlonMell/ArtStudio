using ArtStudio.Core.Dto;
using ArtStudio.Core.Models;

namespace ArtStudio.Core.Services;

public interface IArtService
{
    Task<List<ArtEntity>> GetAll();
    Task<ArtEntity?> Get(Guid id);
    Task<ArtEntity?> Add(ArtRequest art);
    Task<ArtEntity?> Update(Guid id, ArtUpdateRequest art);
    Task<ArtEntity?> Delete(Guid id);
}