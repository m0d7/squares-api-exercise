using Microsoft.AspNetCore.Mvc;
using Squares.Api.Presenters;
using Squares.Application.Dtos;
using Squares.Application.Interfaces.UseCases;
using Squares.Application.Requests;
using Squares.Application.Responses;
using Squares.Application.UseCases;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Squares.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquaresController : ControllerBase
    {
        private readonly ILogger<SquaresController> _logger;
        private readonly ICreateSquaresDetectionEntryUseCase _createNewPointsListUseCase;
        private readonly IGetSquaresDetectionEntriesListUseCase _getIdentifiedSquaresListingUseCase;
        private readonly IAddNewPointToDetectionSquaresEntryUseCase _addNewPointToDetectionSquaresEntryUseCase;
        private readonly IRemovePointFromDetectionSquaresEntryUseCase _removePointFromDetectionSquaresEntryUseCase;
        private readonly SquaresDetectionEntryPresenter _identifiedSquaresPresenter;
        private readonly SquaresDetectionEntriesListPresenter _identifiedSquaresListingPresenter;

        public SquaresController(ILogger<SquaresController> logger,
            ICreateSquaresDetectionEntryUseCase createNewPointsListUseCase,
            IGetSquaresDetectionEntriesListUseCase getIdentifiedSquaresListingUseCase,
            IAddNewPointToDetectionSquaresEntryUseCase addNewPointToDetectionSquaresEntryUseCase,
            IRemovePointFromDetectionSquaresEntryUseCase removePointFromDetectionSquaresEntryUseCase,
            SquaresDetectionEntryPresenter identifiedSquaresPresenter,
            SquaresDetectionEntriesListPresenter identifiedSquaresListingPresenter)
        {
            _logger = logger;
            _createNewPointsListUseCase = createNewPointsListUseCase;
            _getIdentifiedSquaresListingUseCase = getIdentifiedSquaresListingUseCase;
            _addNewPointToDetectionSquaresEntryUseCase = addNewPointToDetectionSquaresEntryUseCase;
            _removePointFromDetectionSquaresEntryUseCase = removePointFromDetectionSquaresEntryUseCase;
            _identifiedSquaresPresenter = identifiedSquaresPresenter;
            _identifiedSquaresListingPresenter = identifiedSquaresListingPresenter;
        }
        /// <summary>
        /// Creates a new Detection Squares Entry where from the privided list of points squares are detected
        /// </summary>
        /// <param name="points">List of unique points (coordinates x and y) (Note: duplicate points are deleted)</param>
        /// <response code="201">Returns newly created Detection Squares Entry where from the provided points the squares are detected and their points are provided </response>
        [HttpPost]
        [Route("/v1/squaresDetectionEntries")]
        [ProducesResponseType(typeof(SquaresDetectionEntryDto), StatusCodes.Status201Created)]
        public IActionResult CreateNewDetectionSquaresEntry([Required] List<PointDto> points)
        {
            if (_createNewPointsListUseCase.Handle(new CreateSquaresDetectionEntryRequest(points), _identifiedSquaresPresenter))
            {
                return CreatedAtAction(
                    nameof(GetDetectionSquaresEntry),
                    new { _identifiedSquaresPresenter.SquaresDetectionEntry.Id },
                    _identifiedSquaresPresenter.SquaresDetectionEntry
                    );
            }
            return StatusCode((int)_identifiedSquaresPresenter.StatusCode, _identifiedSquaresPresenter.ErrorMessage);
        }

        /// <summary>
        /// Returns all available Detection Squares Entries
        /// </summary>
        /// <response code="200">Returns all available Detection Squares Entries </response>
        [HttpGet]
        [Route("/v1/squaresDetectionEntries")]
        [ProducesResponseType(typeof(IList<SquaresDetectionEntryDto>), StatusCodes.Status201Created)]
        public IActionResult GetAvailableDetectionSquaresEntries()
        {
            if (_getIdentifiedSquaresListingUseCase.Handle(new GetISquaresDetectionEntriesListRequest(), _identifiedSquaresListingPresenter))
            {
                return Ok(_identifiedSquaresListingPresenter.SquaresDetectionEntriesList);
            }
            return StatusCode((int)_identifiedSquaresPresenter.StatusCode, _identifiedSquaresPresenter.ErrorMessage);
        }

        [HttpGet]
        [Route("/v1/squaresDetectionEntries/{id}")]
        [ProducesResponseType(typeof(SquaresDetectionEntryDto), StatusCodes.Status201Created)]
        public IActionResult GetDetectionSquaresEntry(string id)
        {
            return BadRequest("Not implemented");
        }

        /// <summary>
        /// Adds a new point to the existing Detection Squares Entry and recalculates the detected squares
        /// </summary>
        /// <response code="201">Returns the modified Detection Squares Entry</response>
        /// <response code="400">The point already exists in this entry</response>
        /// <response code="404">The entry with the provided id does not exist</response>
        [HttpPost]
        [Route("/v1/squaresDetectionEntries/{id}/inputPoints")]
        [ProducesResponseType(typeof(SquaresDetectionEntryDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddPointToSquaresDetectionEntry(string id, [Required] [FromBody] PointDto point)
        {
            if (_addNewPointToDetectionSquaresEntryUseCase.Handle(new RemoveOrAddPointInDetectionSquaresEntryRequest(id, point), _identifiedSquaresPresenter))
            {
                return Ok(_identifiedSquaresPresenter.SquaresDetectionEntry);
            }
            return StatusCode((int)_identifiedSquaresPresenter.StatusCode, _identifiedSquaresPresenter.ErrorMessage);
        }


        [HttpDelete]
        [Route("/v1/squaresDetectionEntries/{id}/inputPoints")]
        [ProducesResponseType(typeof(SquaresDetectionEntryDto), StatusCodes.Status201Created)]
        public IActionResult DeletePointInSquaresDetectionEntry(string id, [Required] [FromBody] PointDto point)
        {
            return BadRequest("Not implemented");
        }

    }
}