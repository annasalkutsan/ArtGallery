using Application.DTO.User;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class PaintingProfile : Profile
    {
        public PaintingProfile()
        {
            CreateMap<PaintingUploadImageRequest, Painting>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Image != null ? src.Image.FileName : null))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore());

            CreateMap<PaintingUpdateRequest, Painting>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImagePath, opt => opt.Ignore()) // Игнорируем ImagePath
                .ForMember(dest => dest.Author, opt => opt.Ignore())   // Игнорируем Author
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore()) // Игнорируем AuthorId
                .ForMember(dest => dest.Order, opt => opt.Ignore())    // Игнорируем Order
                .ForMember(dest => dest.OrderId, opt => opt.Ignore()); // Игнорируем OrderId

            CreateMap<Painting, PaintingResponse>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));
        }

    }
}