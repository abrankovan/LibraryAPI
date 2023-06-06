using AutoMapper;
using StudentApp.Dtos;
using StudentApp.Entities;

namespace StudentApp.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile() 
        { 
            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();
        }
    }
}
