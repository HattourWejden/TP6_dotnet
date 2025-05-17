using AutoMapper;
using SchoolApi.DTOs;
using SchoolApi.Models;


namespace SchoolApi.DTOs
{
    public class SchoolsAutoMapperProfile : Profile
    {
        public SchoolsAutoMapperProfile()
        {
            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>().ForMember(dest => dest.Director, opt => opt.MapFrom(src => ""));
        }
    }
}