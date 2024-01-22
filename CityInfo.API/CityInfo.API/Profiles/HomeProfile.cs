using AutoMapper;

namespace CityInfo.API.Profiles
{
    public class HomeProfile: Profile
    {
        public HomeProfile() 
        {
            CreateMap<Entities.City, Models.SearchDto>();
            CreateMap<Entities.PointOfInterest, Models.SearchDto>();
        }
    }
}
