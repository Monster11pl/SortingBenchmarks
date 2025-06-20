using Application.Models;
using AutoMapper;
using Data.Entities;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Benchmark, BenchmarkResult>()
            .ForMember(x => x.SortType, opt => opt.MapFrom(src => src.SortAlgorithm) )
            .ForMember(x => x.Time, opt => opt.MapFrom(src => src.ExecutionTime) )
            .ForMember(x => x.ElementsCount, opt => opt.MapFrom(src => src.Elements) )
            .ReverseMap();

        CreateMap<BenchmarkHardwareInfo, BenchmarkHardwareInfoDto>()
            .ReverseMap();
    }
}