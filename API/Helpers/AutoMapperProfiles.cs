using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
                src.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(dest => dest.Age, opt =>
             opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();

            CreateMap<Message, MessageDto>()
            .ForMember(u => u.SenderPhotoUrl, opt => opt.MapFrom(
                   src => src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url
               ))
               .ForMember(u => u.RecipientPhotoUrl, opt => opt.MapFrom(
                   src => src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url
               ));
        }
    }
}