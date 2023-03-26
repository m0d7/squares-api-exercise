using AutoMapper;
using Squares.Entities.DTO;
using Squares.Entities.Models;

namespace Squares.API.Configurations;

public class CustomMapperConfiguration : Profile
{
    public CustomMapperConfiguration()
    {
        CreateMap<Surface, SurfaceDto>();
        CreateMap<SurfaceDto, Surface>();

        CreateMap<Square, SquareDto>()
            .ForMember(dto => dto.Points, opt => opt.MapFrom(model => model.Points));
        CreateMap<SquareDto, Square>()
            .ForMember(model => model.Points, opt => opt.MapFrom(dto => dto.Points));

        CreateMap<Point, PointDto>();
        CreateMap<PointDto, Point>();
    }
}