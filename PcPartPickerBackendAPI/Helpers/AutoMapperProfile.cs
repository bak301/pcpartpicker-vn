using AutoMapper;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Dtos;

namespace PcPartPickerBackendAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
