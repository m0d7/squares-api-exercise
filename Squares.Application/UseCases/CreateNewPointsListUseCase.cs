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
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.UseCases
{
    public class CreateNewPointsListUseCase : ICreateSquaresDetectionEntryUseCase
    {
        private readonly IMapper _mapper;
        private readonly ISquaresDetectionEntriesRepository _identifiedSquaresRepository;
        public CreateNewPointsListUseCase(IMapper mapper, ISquaresDetectionEntriesRepository identifiedSquaresRepository)
        {
            _mapper = mapper;
            _identifiedSquaresRepository = identifiedSquaresRepository;
        }
        public bool Handle(CreateSquaresDetectionEntryRequest request, IOutputPort<SquaresDetectionEntryResponse> outputPort)
        {
            var newSqaure = new SquaresDetectionEntry(Guid.NewGuid().ToString(), _mapper.Map<List<PointDto>, List<Point>>(request.Points.Distinct().ToList()));

            newSqaure.IdentifySquares();
            _identifiedSquaresRepository.AddAsync(newSqaure);

            outputPort.Handle(new SquaresDetectionEntryResponse(_mapper.Map<SquaresDetectionEntryDto>(newSqaure)));

            return true;
        }
    }
}
