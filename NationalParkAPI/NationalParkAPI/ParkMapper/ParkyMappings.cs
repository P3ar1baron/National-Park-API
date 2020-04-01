using AutoMapper;
using NationalParkAPI.Models;
using NationalParkAPI.Models.Dto;
using NationalParkAPI.Models.Dtos;

namespace NationalParkAPI.ParkMapper
{
    public class ParkyMappings : Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trail, TrailDto>().ReverseMap();
            CreateMap<Trail, TrailUpsertDto>().ReverseMap();
        }
    }
}
