using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Squares.Contracts.Interfaces;
using Squares.Entities.DTO;
using Squares.Entities.Models;

namespace Squares.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurfaceController : ControllerBase
{
    private readonly ILogger<SurfaceController> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public SurfaceController(ILogger<SurfaceController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<IActionResult> GetSurfaces()
    {
        var surfaces = await unitOfWork.Surfaces.ListAsync();

        var surfacesDto = mapper.Map<List<SurfaceDto>>(surfaces);

        return Ok(surfacesDto);
    }

    [HttpPost("UpdateSurface/{surfaceId:int}")]
    public async Task<IActionResult> UpdateSurface(int surfaceId, SurfaceDto surfaceDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (surfaceId <= 0)
        {
            return BadRequest("Id cannot be equal to or lower than 0.");
        }
        
        var surface = await this.unitOfWork.Surfaces.GetByIdAsync(surfaceId);

        if (surface == null)
        {
            return BadRequest("Such surface doesn't exist.");
        }

        surface.TemplateName = surfaceDto.TemplateName;
        
        await this.unitOfWork.Surfaces.UpdateAsync(surface);
        
        await this.unitOfWork.SaveAsync();

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> InsertSurface(SurfaceDto surfaceDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var surface = this.mapper.Map<Surface>(surfaceDto);

        await this.unitOfWork.Surfaces.AddAsync(surface);
        
        await this.unitOfWork.SaveAsync();

        return Ok();
    }

    [HttpDelete("${surfaceId:int}")]
    public async Task<IActionResult> DeleteSurface(int surfaceId)
    {
        if (surfaceId <= 0)
        {
            return BadRequest("Id cannot be equal to or lower than 0.");
        }

        var surface = await this.unitOfWork.Surfaces.GetByIdAsync(surfaceId);

        if (surface == null)
        {
            return BadRequest("Such surface doesn't exist.");
        }

        await this.unitOfWork.Surfaces.RemoveByIdAsync(surfaceId);

        await this.unitOfWork.SaveAsync();
        
        return NoContent();
    }
}