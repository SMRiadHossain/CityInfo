using CityInfo.API.Entities;
using CityInfo.API.Models;
namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync();

        Task<City?> GetCityAsync(int cityId, bool includePointOfInterest);
        Task<User> GetUserAsync(int userId);
        Task<bool> CityExistAsync(int cityId);
        Task<IEnumerable<PointOfInterest>> GetPointOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId,
            int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId,int userId, PointOfInterest pointOfInterest);

        Task<City> AddCityAsync(City city);

        Task<User> AddNewUserAsync(User user);

        

        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        void DeleteCity(City city);

        Task<bool> SaveChangesAsync();



        Task<bool> UserExistAsync(string userName);
        Task<bool> UserExistAsync(int userId);
        Task<bool> PasswordValidAsync(string password);
        Task AddNewUserAsync(UserDto finalUSerDetails);
    }
}
