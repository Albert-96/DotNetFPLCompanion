using AutoMapper;
using FPLCompanion.Data.Entities;
using FPLCompanion.Dto;
using FPLCompanion.Dto.Grid;

namespace FPLCompanion.Dependencies
{
    public class ConfigureMapper : Profile
    {
        public ConfigureMapper()
        {
            CreateMap<ElementDto, Element>()
                .ForMember(x => x.Team, y => y.MapFrom(x => x.teamInfo))
                .ForMember(x => x.ElementType, y => y.MapFrom(x => x.positionInfo))
                .ReverseMap();
            CreateMap<TeamDto, Team>()
                .ReverseMap();
            CreateMap<ElementTypeDto, ElementType>()
                .ReverseMap();
            CreateMap<GridFilter, FilterDto>()
                .ReverseMap();
        }
    }
}
