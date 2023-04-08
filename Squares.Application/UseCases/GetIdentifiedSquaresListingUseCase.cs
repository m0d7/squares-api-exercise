using AutoMapper;
using Squares.Application.Dtos;
using Squares.Application.Interfaces;
using Squares.Application.Interfaces.Repositories;
using Squares.Application.Interfaces.UseCases;
using Squares.Application.Requests;
using Squares.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Application.UseCases
{
    public class GetIdentifiedSquaresListingUseCase : IGetSquaresDetectionEntriesListUseCase
    {
        private readonly ISquaresDetectionEntriesRepository _identifiedSquaresRepository;
        private readonly IMapper _mapper;

        public GetIdentifiedSquaresListingUseCase(ISquaresDetectionEntriesRepository identifiedSquaresRepository, IMapper mapper)
        {
            _identifiedSquaresRepository = identifiedSquaresRepository;
            _mapper = mapper;
        }
        public bool Handle(GetISquaresDetectionEntriesListRequest request, IOutputPort<SquaresDetectionEntriesListResponse> outputPort)
        {
            try
            {
                outputPort.Handle(new SquaresDetectionEntriesListResponse(_mapper.Map<IList<SquaresDetectionEntryDto>>(_identifiedSquaresRepository.GetAllAsync())));
                return true;

            } catch (Exception ex)
            {
                outputPort.Handle(new SquaresDetectionEntriesListResponse(HttpStatusCode.InternalServerError, ex.Message));
                return false;
            }
            
        }
    }
}
