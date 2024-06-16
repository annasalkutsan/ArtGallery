﻿using Application.DTO.User;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;

namespace Application.MappingProfiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateRequest, User>()
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PaymentDetails, opt => opt.MapFrom(src => src.PaymentDetails))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
            .ForMember(dest => dest.Orders, opt => opt.Ignore()); // Assuming Orders are not part of the request

        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PaymentDetails, opt => opt.MapFrom(src => src.PaymentDetails))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
    }
}