
using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entites;

namespace ECommerce.Core.Mappers;

public class RegisterRequestToApplicationUserMappingProfile : Profile
{
    public RegisterRequestToApplicationUserMappingProfile()
    { 
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Email, opt =>opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.UserID, opt => opt.Ignore());
    }
}
