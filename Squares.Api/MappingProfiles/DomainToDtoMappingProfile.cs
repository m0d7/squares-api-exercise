using AutoMapper;
using Squares.Application.Dtos;
using Squares.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares.Api.MappingProfiles
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        {
            CreateMap<Point, PointDto>().ReverseMap();
            CreateMap<Square, SquareDto>().ReverseMap();
            CreateMap<SquaresDetectionEntry, SquaresDetectionEntryDto>().ReverseMap();
        }
    }
}
