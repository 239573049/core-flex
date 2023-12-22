using AutoMapper;
using TokenGpt.Contract.Services.Dto;
using TokenGpt.Rcl.Model;

namespace TokenGpt.Rcl.MapperProfiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<ApplicationInput,ApplicationEntity>();
        CreateMap<ApplicationDto, ApplicationEntity>().ReverseMap();
    }
}