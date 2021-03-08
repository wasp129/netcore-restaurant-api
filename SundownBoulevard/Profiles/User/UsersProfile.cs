using AutoMapper;
using SundownBoulevard.Dtos.User;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Profiles.User
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserModel, UserReadDto>();
            CreateMap<UserCreateDto, UserModel>();
            CreateMap<UserUpdateDto, UserModel>();
            CreateMap<UserModel, UserUpdateDto>();
        }
    }
}