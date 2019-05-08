using AutoMapper;
using Cookbook.Api.Features.User.Dto;
using Entities = Cookbook.Api.Data.Entities;

namespace Cookbook.Api.Features.User.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, UserDto>();
            CreateMap<UserDto, Entities.User>();
        }
    }
}
