using ArtStudio.Core.Context;
using ArtStudio.Core.Dto;
using ArtStudio.Core.Errors;
using ArtStudio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtStudio.Core.Services;

public class ArtService(ArtStudioDbContext dbContext) : IArtService
{
    public async Task<List<ArtEntity>> GetAll()
    {
        return await dbContext.Arts
            .AsNoTracking()
            .OrderBy(art => art.CreatedOn)
            .ToListAsync() 
               ?? throw ServiceException.NotFound("Arts not found.");
    }
    
    public async Task<ArtEntity?> Get(Guid id)
    {
        return await dbContext.Arts
            .AsNoTracking()
            .FirstOrDefaultAsync(art => art.Id == id)
            ?? throw ServiceException.NotFound("Art not found.");
    }
    
    public async Task<ArtEntity?> Add(ArtRequest art)
    {
        var artEntity = new ArtEntity
        {
            Id = art.Id ?? Guid.NewGuid(),
            Name = art.Name ?? throw ServiceException.BadRequest("Name not specified."),
            Price = art.Price ?? 0.00m,
            Description = art.Description ?? string.Empty
        };
        await dbContext.AddAsync(artEntity);
        await dbContext.SaveChangesAsync();
        return await dbContext.Arts.FirstOrDefaultAsync(a => a.Id == artEntity.Id);
    }

    public async Task<ArtEntity?> Update(ArtRequest art)
    {
        var artEntity = new ArtEntity
        {
            Id = art.Id ?? throw ServiceException.BadRequest("Id not specified."),
            Name = art.Name ?? throw ServiceException.BadRequest("Name not specified."),
            Price = art.Price ?? 0.00m,
            Description = art.Description ?? string.Empty
        };
        await dbContext.Arts
            .Where(a => a.Id == art.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(a => a.Id, artEntity.Id)
                .SetProperty(a => a.Name, artEntity.Name)
                .SetProperty(a => art.Price, artEntity.Price)
                .SetProperty(a => art.Description, artEntity.Description));
        return await dbContext.Arts.FirstOrDefaultAsync(a => a.Id == art.Id);
    }

    public async Task<ArtEntity?> Delete(Guid id)
    {
        var result = dbContext.Arts.FirstOrDefaultAsync(a => a.Id == id);
        if (result is null) throw ServiceException.BadRequest("Art with this id was not found.");
        await dbContext.Arts
            .Where(art => art.Id == id)
            .ExecuteDeleteAsync();
        return await result;
    }
}