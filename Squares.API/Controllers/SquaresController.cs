using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Squares.Contracts.Interfaces;
using Squares.Entities.DTO;
using Squares.Entities.Models;

namespace Squares.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SquaresController : ControllerBase
{
    private readonly ILogger<SquaresController> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly ISquareValidator squareValidator;

    public SquaresController(ILogger<SquaresController> logger, IUnitOfWork unitOfWork, IMapper mapper, ISquareValidator squareValidator)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this.squareValidator = squareValidator ?? throw new ArgumentNullException(nameof(squareValidator));
    }

    [HttpGet]
    public async Task<IActionResult> GetSquares()
    {
        var squares = await unitOfWork.Squares.ListAsync();
        
        foreach (var square in squares)
        {
            square.Points = this.unitOfWork.Points.FindAsync(x => x.SquareId == square.Id).Result.ToList();
        }

        var squaresDto = mapper.Map<List<SquareDto>>(squares);

        return Ok(squaresDto);
    }
    
    [HttpGet("Surface/{surfaceId:int}")]
    public async Task<IActionResult> GetSurfaceSquares(int surfaceId)
    {
        if (surfaceId <= 0)
        {
            return BadRequest("Surface id cannot be equal or lower than 0.");
        }

        var surface = await this.unitOfWork.Surfaces.GetByIdAsync(surfaceId);

        if (surface == null)
        {
            return BadRequest("Such surface doesn't exist.");
        }

        var squares = await this.unitOfWork.Squares.FindAsync(x => x.SurfaceId == surfaceId);
        
        foreach (var square in squares)
        {
            square.Points = this.unitOfWork.Points.FindAsync(x => x.SquareId == square.Id).Result.ToList();
        }
        
        var squaresDto = mapper.Map<List<SquareDto>>(squares);

        return Ok(squaresDto);
    }

    [HttpPost("{squareId:int}")]
    public async Task<IActionResult> UpdateSquare(int squareId, SquareDto squareDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (squareId <= 0)
        {
            return BadRequest("Id cannot be equal to or lower than 0.");
        }
        
        var square = await this.unitOfWork.Squares.GetByIdAsync(squareId);

        if (square == null)
        {
            return BadRequest("Such square doesn't exist.");
        }
        
        var squarePoints = squareDto.Points;

        if (!this.squareValidator.IsSquare(squarePoints[0], squarePoints[1], squarePoints[2], squarePoints[3]))
        {
            return BadRequest("Array of points doesn't make a square.");
        }

        var mappedSquare = this.mapper.Map<Square>(squareDto);

        square.Points = mappedSquare.Points;

        await this.unitOfWork.Squares.AddAsync(square);
        await this.unitOfWork.SaveAsync();

        return Ok();
    }

    [HttpPost("InsertSurfaceSquare/{surfaceId:int}")]
    public async Task<IActionResult> InsertSquare(int surfaceId,SquareDto squareDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (surfaceId <= 0)
        {
            return BadRequest("Surface id cannot be equal or lower than 0.");
        }

        var surface = await this.unitOfWork.Surfaces.GetByIdAsync(surfaceId);

        if (surface == null)
        {
            return BadRequest("Such surface doesn't exist.");
        }
        
        var squarePoints = squareDto.Points;

        if (!this.squareValidator.IsSquare(squarePoints[0], squarePoints[1], squarePoints[2], squarePoints[3]))
        {
            return BadRequest("Array of points doesn't make a square.");
        }
        
        var square = this.mapper.Map<Square>(squareDto);
        
        square.SurfaceId = surfaceId;
        square.Surface = surface;

        await this.unitOfWork.Squares.AddAsync(square);
        await this.unitOfWork.SaveAsync();
        
        return Ok();
    }

    [HttpDelete("${squareId:int}")]
    public async Task<IActionResult> DeleteSquare(int squareId)
    {
        if (squareId <= 0)
        {
            return BadRequest("Id cannot be equal to or lower than 0.");
        }

        var square = await this.unitOfWork.Squares.GetByIdAsync(squareId);

        if (square == null)
        {
            return BadRequest("Such square doesn't exist.");
        }

        await this.unitOfWork.Squares.RemoveByIdAsync(squareId);

        await this.unitOfWork.SaveAsync();
        
        return NoContent();
    }
}