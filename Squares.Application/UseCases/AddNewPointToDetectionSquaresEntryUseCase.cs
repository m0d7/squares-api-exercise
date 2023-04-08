using AutoMapper;
using Squares.Application.Dtos;
using Squares.Application.Interfaces;
using Squares.Application.Interfaces.Repositories;
using Squares.Application.Interfaces.UseCases;
using Squares.Application.Requests;
using Squares.Application.Responses;
using Squares.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.UseCases
{
    public class AddNewPointToDetectionSquaresEntryUseCase : IAddNewPointToDetectionSquaresEntryUseCase
    {
        private readonly IMapper _mapper;
        private readonly ISquaresDetectionEntriesRepository _identifiedSquaresRepository;

        public AddNewPointToDetectionSquaresEntryUseCase(IMapper mapper, ISquaresDetectionEntriesRepository identifiedSquaresRepository)
        {
            _mapper = mapper;
            _identifiedSquaresRepository = identifiedSquaresRepository;
        }

        public bool Handle(RemoveOrAddPointInDetectionSquaresEntryRequest request, IOutputPort<SquaresDetectionEntryResponse> outputPort)
        {
            var entry = _identifiedSquaresRepository.GetByIdAsync(request.EntryId);

            if (entry == null) {
                outputPort.Handle(new SquaresDetectionEntryResponse(System.Net.HttpStatusCode.NotFound, $"DetectionSquaresEntry with id {request.EntryId} was not found"));
                return false;
            }
            if (entry.InputPoints.Contains(_mapper.Map<Point>(request.Point))) 
            {
                outputPort.Handle(new SquaresDetectionEntryResponse(System.Net.HttpStatusCode.BadRequest, $"DetectionSquaresEntry with id {request.EntryId} already has this point ({request.Point.X}, {request.Point.Y})"));
                return false;
            }
                
            entry.InputPoints.Add(_mapper.Map<Point>(request.Point));

            entry.IdentifySquares();

            _identifiedSquaresRepository.UpdateAsync(entry);

            outputPort.Handle(new SquaresDetectionEntryResponse(_mapper.Map<SquaresDetectionEntryDto>(entry)));
            return true;

        }
    }
}
