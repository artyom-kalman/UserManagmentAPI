using AutoMapper;
using UserManagmentAPI.Dto;
using UserManagmentAPI.Models;

namespace UserManagmentAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserState, UserStateDto>();
            CreateMap<UserGroup, UserGroupDto>();
        }
    }
}
