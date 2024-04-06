using ArtStudio.Core.Dto;
using ArtStudio.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtStudio.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtsController(IArtService artService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ArtResponse>>> GetArts()
    {
        var arts = await artService.GetAll();
        var response = arts.Select(a => new ArtResponse
            (a.Id, a.CreatedOn, a.Name, a.Price, a.Description));
        return Ok(response);
    }
    
    [HttpGet("{artId}")]
    public async Task<ActionResult<ArtResponse>> GetArt([FromRoute] Guid artId)
    {
        var art = await artService.Get(artId);
        var response = new ArtResponse
            (art.Id, art.CreatedOn, art.Name, art.Price, art.Description);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<ArtResponse>> AddArt([FromBody] ArtRequest artRequest)
    {
        var art = await artService.Add(artRequest);
        var response = new ArtResponse
            (art.Id, art.CreatedOn, art.Name, art.Price, art.Description);
        return Ok(response);
    }
    
    [HttpDelete("{artId}")]
    public async Task<ActionResult<ArtResponse>> DeleteArt([FromRoute] Guid artId)
    {
        var art = await artService.Delete(artId);
        var response = new ArtResponse
            (art.Id, art.CreatedOn, art.Name, art.Price, art.Description);
        return Ok(response);
    }
}