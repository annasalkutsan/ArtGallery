using Application.DTO.User;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles;

public class AuthorProfile:Profile 
{
    public AuthorProfile()
    {
        CreateMap<AuthorCreateRequest, Author>()
            .ForMember(dest => dest.NumberOfWorks, opt => opt.MapFrom(src => src.NumberOfWorks))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Paintings, opt => opt.Ignore()); // Ignoring Paintings as it is not part of the request
       
        CreateMap<Author, AuthorResponse>()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.NumberOfWorks, opt => opt.MapFrom(src => src.NumberOfWorks))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
    
        CreateMap<AuthorUpdateRequest, Author>()
            .ForMember(dest => dest.NumberOfWorks, opt => opt.MapFrom(src => src.NumberOfWorks))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Paintings, opt => opt.Ignore()); // Ignoring Paintings as it is not part of the request
    }
}