using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Convert AppUser to MemberDTO
            CreateMap<AppUser, MemberDTO>();

            //Convert Photo to PhotoDTO
            CreateMap<Photo, PhotoDTO>();
        }
    }
}