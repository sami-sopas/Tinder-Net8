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
            //Convert AppUser to MemberDTO
            CreateMap<AppUser, MemberDTO>()
                //Para realizar alguna accion de un campo, se usa ForMember
                .ForMember(
                    dest => dest.PhotoUrl, //Destino: MemberDTO.PhotoUrl
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url)). //Origen: AppUser.Photos.Url (donde IsMain == true)
                ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge())
                );

            //Convert Photo to PhotoDTO
            CreateMap<Photo, PhotoDTO>();
        }
    }
}