using Application.DTO.User;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateRequest, Order>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.PaintingId, opt => opt.MapFrom(src => src.PaintingId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Painting, opt => opt.Ignore()) // Ignoring navigation properties
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<OrderUpdateRequest, Order>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Игнорируем Id, так как он будет сгенерирован базой данных
                .ForMember(dest => dest.Painting, opt => opt.Ignore()) // Игнорируем Painting, так как нет информации о нем в OrderUpdateRequest
                .ForMember(dest => dest.PaintingId, opt => opt.Ignore()) // Игнорируем PaintingId, так как нет информации о нем в OrderUpdateRequest
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Игнорируем User, так как нет информации о нем в OrderUpdateRequest
                .ForMember(dest => dest.UserId, opt => opt.Ignore()); // Игнорируем UserId, так как нет информации о нем в OrderUpdateRequest

            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.PaintingId, opt => opt.MapFrom(src => src.PaintingId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}