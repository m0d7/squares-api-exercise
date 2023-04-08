using AutoMapper;
using Squares.Application.Interfaces;
using Squares.Application.Interfaces.Repositories;
using Squares.Application.Interfaces.UseCases;
using Squares.Application.Requests;
using Squares.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.UseCases
{
    public class RemovePointFromDetectionSquaresEntryUseCase : IRemovePointFromDetectionSquaresEntryUseCase
    {
        private readonly IMapper _mapper;
        private readonly ISquaresDetectionEntriesRepository _identifiedSquaresRepository;

        public RemovePointFromDetectionSquaresEntryUseCase(IMapper mapper, ISquaresDetectionEntriesRepository identifiedSquaresRepository)
        {
            _mapper = mapper;
            _identifiedSquaresRepository = identifiedSquaresRepository;
        }

        public bool Handle(RemoveOrAddPointInDetectionSquaresEntryRequest request, IOutputPort<SquaresDetectionEntryResponse> outputPort)
        {
            throw new NotImplementedException();
        }
    }
}
