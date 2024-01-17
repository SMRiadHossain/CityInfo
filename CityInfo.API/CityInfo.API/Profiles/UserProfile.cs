using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Entities.User, Models.UserWithoutCityDto>();
            CreateMap<Models.UserForCreationDto, Entities.User>();
            CreateMap<Models.UserForLoginDto, Entities.User>();

        }
        
    }
}
